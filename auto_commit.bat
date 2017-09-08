@echo off

set Info=
set /p Info=请输入版本提交信息：

"C:\Program Files (x86)\Git\bin\git.exe"  add .
"C:\Program Files (x86)\Git\bin\git.exe"  commit -m   %Info%
"C:\Program Files (x86)\Git\bin\git.exe"  push -u  git@git.oschina.net:ZKHD/KaiYuanFeiKongBeiFen.git

pause


