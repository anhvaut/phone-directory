using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;

namespace WPF_Threading_CSharp
{
	public partial class AsynchronousDemo : Window
	{
		#region Private Matters

		private System.ComponentModel.BackgroundWorker backgroundWorker = new System.ComponentModel.BackgroundWorker();

		#endregion

		#region Constructor

		/// <summary>
		/// Create new instance of AsynchronousDemo and do some setup
		/// </summary>
		public AsynchronousDemo()
		{
			InitializeComponent();

			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);

			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.WorkerReportsProgress = true;

			NameScope.SetNameScope(this, new NameScope());
			lastStackPanel.RegisterName("wpfProgressBar", wpfProgressBar);
		}

		#endregion


		
		

		/// <summary> 
		/// Handles click event for wpfAsynchronousStart button. 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		/// <remarks></remarks> 
		private void WPFAsynchronousStart_Click(object sender, System.Windows.RoutedEventArgs e) 
		{ 
			this.wpfCount.Text = ""; 
			this.wpfAsynchronousStart.IsEnabled = false; 
			this.wpfAsynchronousCancel.IsEnabled = true; 
		    
			// Calls DoWork on secondary thread 
			this.backgroundWorker.RunWorkerAsync(); 
		    
			// RunWorkerAsync returns immediately, start progress bar 
			wpfProgressBarAndText.Visibility = Visibility.Visible; 
		} 

		/// <summary> 
		/// Runs on secondary thread. 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		/// <remarks></remarks> 
		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) 
		{
			// call long running process and get result 
			e.Result = this.SomeLongRunningMethodWPF();
		    
			// Cancel if cancel button was clicked. 
			if (this.backgroundWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			} 
		} 

		/// <summary> 
		/// Method is called everytime backgroundWorker.ReportProgress is called which triggers ProgressChanged event. 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		/// <remarks></remarks> 
		private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) 
		{ 
			// Update UI with % completed. 
			this.wpfCount.Text = e.ProgressPercentage.ToString() + "% processed.";
            listBox1.Items.Add(e.UserState.ToString());
		} 

		/// <summary> 
		/// Called when DoWork has completed. 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		/// <remarks></remarks> 
		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) 
		{ 
			// Back on primary thread, can access ui controls 
			//wpfProgressBarAndText.Visibility = Visibility.Collapsed;

			if (e.Cancelled)
			{
				this.wpfCount.Text = "Process Cancelled.";
			}
			else
			{
				this.wpfCount.Text = "Processing completed. " + (string)e.Result + " rows processed.";
			}
		    
			//this.myStoryboard.Stop(this.lastStackPanel); 
		    
			this.wpfAsynchronousStart.IsEnabled = true; 
		    
			this.wpfAsynchronousCancel.IsEnabled = false; 
		} 

		/// <summary> 
		/// Handles click event for cancel button. 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		/// <remarks></remarks> 
		private void WPFAsynchronousCancel_Click(object sender, System.Windows.RoutedEventArgs e) 
		{ 
			// Cancel the asynchronous operation. 
			this.backgroundWorker.CancelAsync(); 
		    
			// Enable the Start button. 
			this.wpfAsynchronousStart.IsEnabled = true; 
		    
			// Disable the Cancel button. 
			this.wpfAsynchronousCancel.IsEnabled = false; 
		} 

		/// <summary> 
		/// Used to simulate a long running function such as database call 
		/// or the iteration of many rows. 
		/// </summary> 
		/// <returns></returns> 
		/// <remarks></remarks> 
		private string SomeLongRunningMethodWPF() 
		{ 
			int iteration = (int)1000000000 / 100; 
			double cnt = 0; 
		    
			for (int i = 0; i <= 1000000000; i++) 
			{ 
		        
				// don't continue if cancel button clicked 
				if (this.backgroundWorker.CancellationPending)
				{
					return "";
				} 
		        
				cnt = cnt + 1; 
		        
				// report progress of loop 
				if ((i % iteration == 0) & (backgroundWorker != null) && backgroundWorker.WorkerReportsProgress) 
				{ 
					backgroundWorker.ReportProgress(i / iteration,"" + i); 
                    
				} 
			} 
			return cnt.ToString(); 
		} 

	}	
}
