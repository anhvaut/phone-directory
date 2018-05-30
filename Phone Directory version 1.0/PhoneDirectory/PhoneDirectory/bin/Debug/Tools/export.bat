cd Tools
csvde -f %1 -s %2 -r objectClass=person -l "DN, displayName, telephoneNumber, mail, homePhone, mobile, facsimileTelephoneNumber, homePostalAddress, ipPhone"
pause

