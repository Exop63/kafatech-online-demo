# KafaTech - Online 2d Demo

Mirror networking ve Unity(2022.3.30f1) oyun motoru ile hazırlanmıştır.


## İndirilebilir Dosyalar

- [Android için APK dosyası](https://github.com/Exop63/kafatech-online-demo/releases/download/Publish/2dDemo.apk)
- [Linux için Uygulama Paketi](https://github.com/Exop63/kafatech-online-demo/releases/download/Publish/Amd64_x86_Linux.tar.gz)
- [Windows için Yürütülebilir Dosyası](https://github.com/Exop63/kafatech-online-demo/releases/download/Publish/Amd64_x86_windows.tar.gz)


# Linux Server ve Host test videosu 

https://youtu.be/hIBW_EaAhcs

## Oynanış Modları

KafaTech 2D Demo, iki farklı oynanış modu sunar: Server Client ve Host Client.

### Server Client Modu

Bu modda, bir oyuncu sunucu olarak işlev görürken, diğer oyuncular istemci olarak sunucuya bağlanır. Sunucu, oyun dünyasını kontrol eder, oyuncuların etkileşimlerini yönetir ve oyun durumunu senkronize eder. Birden fazla oyuncunun aynı oyun dünyasında etkileşimde bulunmasını sağlar.

Oyun, farklı çözünürlüklerde eşleşecek şekilde tasarlanmıştır. Server modunda oynanırken, oyun dünyasının görüntüsü, sunucu ekranının çözünürlüğüne uygun olarak oluşturulur ve bu görüntü istemcilere gönderilir.

### Host Client Modu

Bu modda, bir oyuncu hem sunucu hem de istemci olarak işlev görür. Diğer oyuncular, bu oyuncunun oluşturduğu oyun odasına katılır ve bu oyuncunun bilgisayarında barındırılan oyun dünyasında birlikte oynarlar. Bu mod, küçük gruplar arasında oynamak için idealdir.

Oyun, farklı çözünürlüklerde eşleşecek şekilde tasarlanmıştır. Host modunda oynanırken, oyun dünyasının görüntüsü, host ekranının çözünürlüğüne uygun olarak oluşturulur. Diğer oyuncular, hostun ekranını referans alarak oyun dünyasını görüntüler.


