@echo off
title EWT
@emmcdl\emmcdl.exe -p com%1 -f %2 -b %3 offline\%4.img
@if %errorlevel% equ 0 start ESC.exe -success
exit