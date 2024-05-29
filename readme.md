# KafaTech - Online 2d Demo

https://youtu.be/hIBW_EaAhcs

## Oynanış Modları

KafaTech 2D Demo, iki farklı oynanış modu sunar: Server Client ve Host Client.

### Server Client Modu

Bu modda, bir oyuncu sunucu olarak işlev görürken, diğer oyuncular istemci olarak sunucuya bağlanır. Sunucu, oyun dünyasını kontrol eder, oyuncuların etkileşimlerini yönetir ve oyun durumunu senkronize eder. Birden fazla oyuncunun aynı oyun dünyasında etkileşimde bulunmasını sağlar.

Oyun, farklı çözünürlüklerde eşleşecek şekilde tasarlanmıştır. Server modunda oynanırken, oyun dünyasının görüntüsü, sunucu ekranının çözünürlüğüne uygun olarak oluşturulur ve bu görüntü istemcilere gönderilir.

### Host Client Modu

Bu modda, bir oyuncu hem sunucu hem de istemci olarak işlev görür. Diğer oyuncular, bu oyuncunun oluşturduğu oyun odasına katılır ve bu oyuncunun bilgisayarında barındırılan oyun dünyasında birlikte oynarlar. Bu mod, küçük gruplar arasında oynamak için idealdir.

Oyun, farklı çözünürlüklerde eşleşecek şekilde tasarlanmıştır. Host modunda oynanırken, oyun dünyasının görüntüsü, host ekranının çözünürlüğüne uygun olarak oluşturulur. Diğer oyuncular, hostun ekranını referans alarak oyun dünyasını görüntüler.


