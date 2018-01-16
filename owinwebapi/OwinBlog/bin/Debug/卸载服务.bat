bat卸载方法：
cd /d %~dp0
@echo on
color 2f
mode con: cols=80 lines=25
echo 请按任意键开始卸载短信发送服务...
pause
OwinBlog.exe uninstall
pause