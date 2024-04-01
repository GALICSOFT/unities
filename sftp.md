# ftp

### ftp upload on windows

* curl
   - call "C:\curl\curl-8.6.0_2-win64-mingw\bin\curl.exe" -u "user id:password" -k "sftp://remote ip:port/server folder/" -T "source file"
* core ftp
   - corecmd.exe -s -OA -u "%SRC_DIR%" "sftp://usr id:pasword@remote ip:port/server folder/"   -output ./ftp.log -log ./ftp.log  -ssl type ftp.log
* winscp
   - winscp" /command "open -certificate=* sftp://usr id:pasword@remote ip:port" start remote_folder
   - winscp" command "open -certificate=* sftp://usr id:pasword@remote ip:port" synchronize remote local_folder remote folder_folder
 
