# Grupa10-DevCrew

# ![alt text](https://github.com/ooad-2017-2018/Grupa10-DevCrew/blob/master/Resources/logo.png) Travel your way


## Članovi tima: 
1. Amir Sijah
2. Irhad Omanović
3. Faruk Šehić

## Opis projekta

Turizam je mnogo popularna grana privrede. Mnoge države ulažu ogromne svote novca kako bi turizam u svojoj zemlji učinio što pristupačnijim i što zanimljivijim. Samim tim javlja se potreba za boljim uvidom u turistička događanja te interakcije na nivou turistička agencija-posjetioc. Posjeta kulturnim znamenitostima, prirodnim ljepotama neke države i slične aktivnosti zahtjeva dobru organizaciju prilikom kreiranja takvih događaja. "Travel your way" može pomoći i posjetiocima (bolji pregled) i turističkim agencijama (bolja organizacija). Imajući ovo na umu, mi smo odlučili da napravimo aplikaciju koja bi adekvatno odgovorila na dati zahtjev.

## Procesi sistema

#### 1. Registracija korisnika

Da bi korisnik koristio aplikaciju poželjno je da se korisnik registruje. Pri tome će unijeti karakteristične informacije o sebi uz jedinstveno korisničko ime i šifru kojim se dati korisnik identificira.
Također ćemo omogućiti pristup aplikaciji za korisnike koji se ne žele registrovati, uz ograničen pristup resursima i funkcionalnostima samog sistema.


#### 2. Registracija turističke agencije

Svaka turistčka agencija koja želi pružati usluge turistima(ili ljubiteljima domovinskih kulturnih dobara) mora biti registrovana na sistemu uz restriktivnu provjeru unesenih podataka. Razlog za takvu provjeru je da se onemogući kreiranje dodatnog računa za jednu agenciju. Jos jedan od razloga za rigoroznu provjeru je da se sprijeci registracija laznih turističkih agencija. 

#### 3. Prijava korisnika na sistem

Korisnik uz ispravno uneseno korisničko ime i šifru(koji su specificirani pri registraciji) se prijavljuje na sistem. U slučaju da korisnik zaboravi korisničko ime ili šifru, tada ga sistem može obavijestiti o podsjećanju korisničkog imena i promjeni šifre. U mail-u će se nalaziti automatski generisan kod pomoću kojeg će se omogućiti korisniku promjena šifre te će se korisnik savjetovati da blagovremeno promijeni šifru na željenu.

#### 4. Prijava agencije na sistem

Agencija uz ispravno uneseno korisničko ime i šifru(koji su specificirani pri registraciji agencije) se prijavljuje na sistem. U slučaju da agencija ne može pristupiti svom sistemu (zaboravi korisničko ime ili šifru), tada je sistem može obavijestiti o podsjećanju korisničkog imena i promjeni šifre. U mail-u će se nalaziti automatski generisan kod pomoću kojeg će se omogućiti agenciji promjena šifre.

#### 5. Registracija novog događaja

Ključna radnja neke turističke agencije jeste registracija događaja koji sama agencija organizuje. Glavne karakteristike samog događaja jesu grad(i adresa gdje će se održati), broj mjesta za događaj, cijena za jednu osobu (mogući popusti), vrijeme i trajanje održavanja, vrsta događaja i druge pojedinosti.

#### 6. Prijava korisnika za događaj

Obični korisnici pri prijavi na sistem dobivaju listu događaja po željenim kriterijima. Željeni kriteriji ne moraju biti specificirani - u tom slučaju korisnik će dobiti listu svih događaja.

#### 7. Obavještenje korisnika o događaju

Automatizam koji obavještava korisnika o statusu događaja koji su od njegovog interesa. Ovo podrazumijeva registraciju novog događaja, prolongiranje, otkazivanje i slično. 








