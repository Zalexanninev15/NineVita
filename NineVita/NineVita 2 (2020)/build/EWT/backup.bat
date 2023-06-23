@echo off
title EWT
@emmcdl\emmcdl.exe -p com%1 -f %2 -d %3 -o %4.img
@if %errorlevel% equ 0 start ESC.exe -success
exit