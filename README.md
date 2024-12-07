Not: git ile indirdiğiniz dosya çalışmaz ise https://drive.google.com/file/d/1ZxQFbdfxqdmOYoOBymkJMANrhgTsaH8L/view?usp=sharing deneyebilirsiniz

GetStats (abstract class): Oyundaki karakterlerin sağlık, hız, ve hasar gibi temel istatistiklerini tutar. Sağlık, hız gibi değerleri okuma ve artırma işlevleri sağlar. Ölüme dair bir kontrol mekanizması içerir.

PlayerController: GetStats sınıfından türetilir ve oyuncu karakterinin hareketini, yönünü, ve silah kullanımını kontrol eder. Oyuncunun fareyle nişan alması, hareket etmesi, ateş etmesi gibi işlemleri yönetir. Weapon sınıfıyla entegre çalışarak silah değiştirme ve ateş etme işlevleri sağlar.

Weapon: Oyuncunun kullanabileceği silahları yönetir. Bir dizi silah prefab'ı arasında geçiş yapmayı sağlar. WeaponStats sınıfını kullanarak her silahın istatistiklerini ve özelliklerini yönetir.

WeaponStats: Silahın ismini, ateş hızını, hasarını ve mermi hızı gibi özellikleri tanımlar. Fire() metodu, ateşleme işleminde mermiyi oluşturur ve hızlandırır. Ayrıca, ateşleme sesi gibi efektleri tetikler.

Enemy: GetStats sınıfından türetilir ve düşmanların hareketlerini, oyuncuyu takip etmelerini ve saldırmalarını yönetir. Öldüklerinde animasyonları tetikler ve yok edilir. Düşmanlar NavMeshAgent ile hareket eder ve oyuncunun yakınında olduklarında saldırıya geçerler.

EnemySpawner: Sahneye rastgele düşmanlar yerleştirir ve düşman sayısını yönetir. Zamanla daha fazla düşman ekleyerek oyunun zorluk seviyesini artırır. Düşmanlar oyuncudan en az 20 birim uzaklıkta doğar.
