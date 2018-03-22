# Grupa10-DevCrew

# Travel your way


<p align="center">
  
<img src="https://github.com/ooad-2017-2018/Grupa10-DevCrew/blob/master/Resources/logo.png" alt="Travel your way"/>

</p>
  



## Članovi tima: 
1. Amir Sijah
2. Irhad Omanović
3. Faruk Šehić

## Opis projekta

Turizam je mnogo popularna grana privrede. Mnoge države ulažu ogromne svote novca kako bi turizam u svojoj zemlji učinile što pristupačnijim i što zanimljivijim. Samim tim javlja se potreba za boljim uvidom u turistička događanja te interakcije na nivou turistička agencija-posjetioc. Posjeta kulturnim znamenitostima, prirodnim ljepotama neke države i slične aktivnosti zahtjevaju dobru organizaciju prilikom kreiranja takvih događaja. "Travel your way" može pomoći i posjetiocima (bolji pregled) i turističkim agencijama (bolja organizacija). Imajući ovo na umu, mi smo odlučili da napravimo aplikaciju koja bi adekvatno odgovorila na dati zahtjev.

## Procesi sistema

#### 1. Registracija korisnika

Da bi korisnik koristio aplikaciju poželjno je da se korisnik registruje. Pri tome će unijeti karakteristične informacije o sebi uz jedinstveno korisničko ime i šifru kojim se dati korisnik identificira. Korisnik tada upisuje osnovne podatke o sebi:
  * Ime
  * Prezime
  * Datum rođenja
  * Država
  * E-mail
  * Korisničko ime
  * Šifra

Također će biti omogućen pristup aplikaciji za korisnike koji se ne žele registrovati, uz ograničen pristup resursima i funkcionalnostima samog sistema. Gost korisnik će imati priliku vidjeti listu aktivnih događaja, ali bez prava na aplikaciju za prisustvo nekom događaju.


#### 2. Registracija turističke agencije

Svaka turistička agencija koja želi pružati usluge turistima(ili ljubiteljima domovinskih kulturnih dobara) mora biti registrovana na sistemu uz restriktivnu provjeru unesenih podataka. Razlog za takvu provjeru je da se onemogući kreiranje dodatnog računa za jednu agenciju. Još jedan od razloga za rigoroznu provjeru je da se sprijeci registracija lažnih turističkih agencija. Agencija tada upisuje osnovne podatke:

  * Naziv agencije
  * Datum osnivanja
  * Sjedište
  * E-mail
  * Šifra

Nakon što agencija aplicira za registraciju iste, administrator pregleda dokumentaciju koju agencija šalje te shodno tome odobrava/odbija zahtjev za registraciju.

#### 3. Prijava korisnikâ aplikacije na sistem

Korisnik(turista ili turistička agencija) uz ispravno uneseno korisničko ime(naziv agencije) i šifru(koji su specificirani pri registraciji) se prijavljuje na sistem. U slučaju da korisnik zaboravi korisničko ime ili šifru, tada ga sistem može obavijestiti o podsjećanju korisničkog imena i promjeni šifre. U mail-u će se nalaziti automatski generisan kod pomoću kojeg će se omogućiti korisniku promjena šifre te će se korisnik savjetovati da blagovremeno promijeni šifru na željenu.

#### 4. Organizacija događaja

Ključna radnja neke turističke agencije jeste registracija događaja koji sama agencija organizuje. Glavne karakteristike samog događaja jesu grad(i adresa gdje će se održati), broj mjesta za događaj, cijena za jednu osobu (mogući popusti), vrijeme i trajanje održavanja, vrsta događaja i druge pojedinosti. Obični korisnici(turisti) pri prijavi na sistem dobivaju listu događaja po željenim kriterijima. Željeni kriteriji ne moraju biti specificirani - u tom slučaju korisnik će dobiti listu svih događaja. Uz događaje postoji i sistem obavještenja za turiste o statusu događaja koji su od njihovog interesa. Ovo podrazumijeva registraciju novog događaja, prolongiranje, otkazivanje i slično.

#### 5. Naplata usluga

Svaka agencija koristi modul za naplatu svojih usluga gdje se kreira posebna forma sa stavkama za troškove i eventualne popuste. Ta forma se šalje korisniku koji aplicira za neki događaj. Nakon uspješne naplate, agencija stavlja korisnika na listu osoba koje idu na događaj, te se vrši transakcija novca sa korisnikovog paypal računa na račun agencije za vrijednost prikazanoj na formi. Da bi korisnik imao pravo na popust(ako postoji za određeni događaj) potrebno je da priloži adekvatne dokumente na formi za prijavu. Takvi dokumenti su neophodni za eventualno obračunavanje popusta (potvrda da je student i tako dalje). Agencija odobrava/odbija zahtjev korisnika.

#### 6. Transakcije vezane za račun korisnika

Da bi se korisnik mogao prijaviti na događaj treba imati otvoren paypal racun(na kojem mora imati dovoljno sredstava) da bi mogao da izvrsi uplatu, a samim tim i prijavi na događaj. 

## Funkcionalnosti

* Mogućnost registracije korisnika sa specificiranim podacima
* Mogućnost prijave korisnika kao gost uz pregled događaja
* Mogućnost registracije agencije 
* Prijave korisnika sistema
* Prikaz restriktivne liste događaja za registrovane korisnike
* Prikaz potpune liste događaja za goste ili registrovane korisnike 
* Mogućnost registracije novog događaja
* Mogućnost prijave na događaj od strane registrovanih korisnika
* Mogućnost otkazivanja rezervacije
* Povrat novca u slucaju otkazivanja rezervacije
* Mogućnost ocjenjivanja agencije od strane registrovanih korisnika
* Mogućnost ostavljanja komentara od strane registrovanih korisnika
* Modifikacija statusa događaja
* Agencija vrši naplatu za svoje usluge
* Pravo na popust

## Akteri

1. **Registrovani korisnik** - akter koji unosi svoje podatke, te se prijavljuje na željene događaje. Posjeduje svoje stanje na računu pomoću kojeg se vrši transakcija novca između korisnika i agencije
2. **Gost korisnik** - akter koji ima uvid u cijelu listu događaja, ali bez mogućnosti prijave na događaje
3. **Turistička agencija** - unosi svoje podatke, registruje nove događaje te modifikuje postojeće.
4. **Administrator** - koordinira i nadgleda rad sistema, verifikuje zahtjeve za registraciju agencija i koordinira stanjem na računu registrovanog korisnika i agencije
5. **Sistem za autorizaciju kartica** - akter zaduzen za naplatu 













