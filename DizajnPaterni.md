# 1. Singleton(kreacijski patern)
## 1.1. Kada koristimo?
Singleton patern koristimo kada je neki objekat potrebno samo jednom instancirati i kada nam je potrebna jedinstvena kontrola pristupa.
npr: Postoji više servera koji mogu uslužiti zahtjev korisnika. Serveri se mogu uključivati/isključivati. 
Potreban je jedan objekat koji zna o stanju cjelokupne mreže i koji će vršiti usmjeravanje saobraćaja.
## 1.2. Kako se koristi?
Moramo imati klasu koja sadrzi mehanizam za instanciranje same sebe. Dakle unutar klase cemo imati private static varijablu koja ce cuvati 
jedinstvenu instancu klase, zatim static metodu preko koje pristupamo singleton klasi, dok inicijalizaciju resursa vrsimo u singleton konstruktoru.
## 1.3. Korišten u projektu?
Ne.
## 1.4. Ako nije, gdje bi bilo dobro mjesto za njegovu upotrebu i zašto?
Nisam siguran da postoji mjesto u nasoj aplikaciji za singleton patern.

# 2. Proxy(strukturni patern)
## 2.1. Kada koristimo?
Koristimo ga kada ne zelimo da neko direktno pristupa objektu nego zelimo da imamo posrednika do stvarnog objekta.
Razlog moze biti sigurnost, moze biti da ne mozemo direktno instancirati objekt(npr. zbog restrikcije pristupa). 
## 2.2. Kako se koristi?
Proxy patern kreira objekte koji kontrolišu kreiranje novih objekata ili pristup određenim
objektima. Proxy je obično mali javni (public) objekat koji stoji ispred kompleksnijeg privatnog
(private) objekta kome se može pristupiti kada su ispunjeni određeni uslovi. 
## 2.3. Koristen u projektu?
Ne.
## 2.4. Ako nije, gdje bi bilo dobro mjesto za njegovu upotrebu?
Karakteristika nase aplikacije jeste da se prvo moramo registrovati a zatim logovati svaki
put kada hoćemo da pristupimo. Kada smo logovani, možemo pristupati i pregledati razlicite događaje.
Sve akcije koje možemo izvesti (prijavljivanje na događaj, ostavljanje utiska(komentar na usluge neke agencije), …) 
počinju u našem internet pretraživaču, a zatim se šalju putem interneta do najbližeg servera. Objekti su stranice, a proxy
objekti su mehanizmi koji dozvoljavaju registrovanje, logovanje i pristup. 

# 3. Strategy(patern ponasanja)
## 3.1. Kada koristimo?
Koristimo ga kada imamo neki algoritam koji posjeduje vise razlicitih verzija.
Strategy patern omogućava klijentu izbor jednog od algoritma iz familije algoritama za korištenje.
npr: Imamo vojnika koji moze napadati na vise razlicitih nacina(nozem, pistoljem itd.), 
a bira neki od tipova algoritma u zavisnosti od situacije u kojoj se nalazi.
## 3.2. Kako se koristi?
Potreban nam je interfejs koji je zajednicki za sve strategije. Za svaku strategiju implementiramo dati interfejs.
Imamo context klasu koja mijenja strategiju i poziva odgovarajući algoritam za odabranu strategiju. U context klasi 
imamo i instancu interfejsa, dok klijent klasa preko context objekta mijenja strategiju.
## 3.3. Koristen u projektu?
Ne.
## 3.4. Ako nije, gdje bi bilo dobro mjesto za njegovu upotrebu i zasto?
Prilikom same prijave korisnik ima tri opcije: registrovani korisnik, gost, agencija.
Za svaki tip korisnika imamo drugačiji prikaz pa samim tim možemo i drugačije podatke dobiti(pomoću api request-a prema našoj bazi).


# 4. Adapter(strukturalni patern)
## 4.1. Kada koristimo?
Adapter patern koristimo kada želimo proširiti funkcionalnosti određene klase koja je već implementirana.
Pri implementaciji ovog paterna, ne mijenjamo postojeću klasu, već modifikujemo interfejs koji klasa implementira.
Obično se koristi za proširenje funkcionalnosti ogromnih klasa.
## 4.2. Kako se koristi?
Kreiramo novu adapter klasu, koja predstavlja posrednika između klase i interfejsa.
## 4.3. Korišten u projektu?
Ne.
## 4.4. Ako nije, gdje bi bilo dobro mjesto za njegovu upotrebu i zašto?
Želimo li proširiti funkcionalnost neke klase poput Korisnika, da može npr. odustati od događaja možemo se poslužiti ovim paternom, mada trenutne klase nisu kompleksnog obima, tako da ne bi predstavljao problem modifikovati samu klasu.

# 5. Decorator(strukturalni patern)
## 5.1. Kada koristimo?
Decorator patern služi za dinamičko dodavanje elemenata i funkcionalnosti postojećim objektima, a da objekat o tome ništa ne zna. 
Obično se koristi za implementaciju različitih kompresija videa, simultano prevođenje itd.
## 5.2. Kako se koristi?
Implementacija ovog paterna podrazumijeva implementaciju klase *Component*, interfejsa *IComponent* te klase *Decorator*.
## 5.3. Korišten u projektu?
Ne.
## 5.4. Ako nije, gdje bi bilo dobro mjesto za njegovu upotrebu i zašto?
Trenutno ne postoji mjesto za upotrebu ovog paterna čija bi implementacija poboljšala kvalitet projekta.

# 6. Prototype(kreacijski patern)
## 6.1. Kada koristimo?
Ako je kreiranje novog objekta resursno zahtjevno, tada je zgodno klonirati postojeći objekat.
To se radi pomoću Prototyoe paterna.
## 6.2. Kako se koristi?
Implementacija ovog paterna podrazumijeva implementaciju klase *Client*, interfejsa *IPrototype* te klase-prototipi.
## 6.3. Korišten u projektu?
Ne.
## 6.4. Ako nije, gdje bi bilo dobro mjesto za njegovu upotrebu i zašto?
Klase u projektu nisu velikog obima i nisu resursno zahtjevne, pa i nema potrebe implementirati ovaj patern.





