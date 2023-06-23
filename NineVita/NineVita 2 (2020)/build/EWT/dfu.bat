@echo off
title EWT
@emmcdl\emmcdl.exe -p com%1 -raw 0xFE
@if %errorlevel% equ 0 start ESC.exe -success
@if %errorlevel% geq 1 start ESC.exe -error
del EDL)