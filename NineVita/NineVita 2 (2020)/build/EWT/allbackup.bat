@echo off
title EWT
@emmcdl\emmcdl.exe -p com%1 -f %2 -d aboot -o %3aboot.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d abootbak -o %3abootbak.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d apdp -o %3apdp.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d batweak -o %3batweak.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d boot -o %3boot.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d cache -o %3cache.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d cmnlib -o %3cmnlib.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d cmnlib64 -o %3cmnlib64.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d cmnlib64bak -o %3cmnlib64bak.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d cmnlibbak -o %3cmnlibbak.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d config -o %3config.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d DDR -o %3DDR.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d devcfg -o %3devcfg.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d devcfgbak -o %3devcfgbak.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d devinfo -o %3devinfo.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d dip -o %3dip.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d dpo -o %3dpo.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d dsp -o %3dsp.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d factory -o %3factory.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d fingerid -o %3fingerid.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d fsc -o %3fsc.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d fsg -o %3fsg.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d keymaster -o %3keymaster.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d keymasterbak -o %3keymasterbak.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d keystore -o %3keystore.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d limits -o %3limits.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d logdump -o %3logdump.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d mcfg -o %3mcfg.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d mdtp -o %3mdtp.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d misc -o %3misc.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d modem -o %3modem.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d modemst1 -o %3modemst1.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d modemst2 -o %3modemst2.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d mota -o %3mota.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d msadp -o %3msadp.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d oem -o %3oem.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d persist -o %3persist.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d recovery -o %3recovery.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d rpm -o %3rpm.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d rpmbak -o %3rpmbak.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d sbl1 -o %3sbl1.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d sbl1bak -o %3sbl1bak.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d sec -o %3sec.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d splash -o %3splash.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d ssd -o %3ssd.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d syscfg -o %3syscfg.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d tz -o %3tz.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d tzbak -o %3tzbak.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d vendor -o %3vendor.img
@emmcdl\emmcdl.exe -p com%1 -f %2 -d ztecfg -o %3ztecfg.img
@if %errorlevel% equ 0 start ESC.exe -success
exit