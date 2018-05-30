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

# 7. Bulider(kreacijski patern)
## 7.1. Kada koristimo?
Builder patern koristimo kada želimo da odvajamo specifikacije kompleksnih objekata od njihove stvarne
konstrukcije. Isti konstrukcijski proces može kreirati različite reprezentacije. Koriste se najčešće u aplikacijama koje kreiraju kompleksne strukture.
## 7.2. Kako se koristi?
Osnovni elementi paterna su: IBuilder- interfejs koji definira pojedinačne dijelove koji se koriste za izgradnju produkta; Director klasa koja sadrži neophodnu sekvencu operacija za izgradnju produkta; Builder klasa koja se poziva od strane direktora (Director klasa) da se izgradi produkt; Product klasa na osnovu koje se kreira objekat koji se gradi preko dijelova. 

U sklopu paterna može biti više direktora i bildera (Director i Builder klase). Klijent klasa preko Construct metode poziva odgovarajuću Director klasu koja spaja dijelove koji se nude preko Builder interfejsa. Product klasa održava listu dijelova koja je rezultat
konstrukcijskog procesa. 
## 7.3. Korišten u projektu?
Ne.
## 7.4. Ako nije, gdje bi bilo dobro mjesto za njegovu upotrebu i zašto?
Klase u projektu nisu velikog obima i nisu kompleksne, pa i nema potrebe implementirati ovaj patern.

# 8. Factory Method(kreacijski patern)
## 8.1. Kada koristimo?
Factory Method paterna koristimo kada želimo da omogućimo kreiranje objekata na način da podklase odluče koju klasu instancirati. 
## 8.2. Kako se koristi?
Različite podklase mogu na različite načine implementirati interfejs. Factory Method instancira odgovarajuću podklasu(izvedenu klasu) preko posebne metode na osnovu informacije od strane klijenta ili na osnovu tekućeg stanja.
## 8.3. Korišten u projektu?
Ne.
## 8.4. Ako nije, gdje bi bilo dobro mjesto za njegovu upotrebu i zašto?
Nema puno izvedenih klasa u našem projektu, tako da je teže naći kontkretnu primjenu ovog paterna.

# 9. Observe(Patern ponašanja)
## 9.1. Kada koristimo?
Observer paterna koristimo kada želimo da uspostavimo relaciju između objekata tako kada jedan objekat promijeni stanje, drugi zainteresirani objekti se obavještavaju.
## 9.2. Kako se koristi?
Struktura ovog paterna se sastoji od:
  Subject klasa – instance ove klase neovisno
mijenjaju svoje stanje i obavještavaju Observers.
  IObserver – Interfejs za Observers, sadrži samo
jednu metodu koja se poziva kada se promijeni
stanje neke Subject instance.
  Observer – konkretna klasa koja obezbjeđuje
konkretnu implementaciju za IObserver interfejs.
  Update – metoda koja formira interfejs između
klasa Subject i Observer.
  Notify -Event mehanizam za pozivanje Update
operacije za sve posmatrače (Observers). 

Implementacija podrazumijeva:
  Subject klasa sadrži privatni događaj (private
event) Notify.
  Kada se njegovo stanje promijeni on aktivira
događaj (event) i šalje svoje stanje kao
parametar Update metodi unutar Observer
klase (metoda mora biti prije registrirana na
Subject klasu).
  Može biti više različitih posmatrača sa svojim
Update metodama.
## 9.3. Korišten u projektu?
Ne.
## 9.4. Ako nije, gdje bi bilo dobro mjesto za njegovu upotrebu i zašto?
Subject klasa bi mogla da bude događaj, IObserver bi bio interfejst sa metodom koja bi se pozivala kada bi se desila promjena na događaju. Agencija bi bila klasa koja bi implementirala IObserver interfejs. Update metoda bi bila metoda tipa obavijesti() koja bi obaviještala sve Korisnike koji su prijavljeni na događaj da je došlo do određenih izmjena.


