<template> 
  <div class="background-image">
    <div class="form-container">
      <div v-if="currentStep === 1 || currentStep === 2 || currentStep === 3">
        <h2>Forma</h2>
      </div>
      <div v-if="currentStep === 4">
        <h2>Plan Treninga</h2>
      </div>
    <form @submit.prevent="handleSubmit">
      <!-- Prva faza pitanja -->
      <div v-if="currentStep === 1">
        <div class="form-group">
          <label class="labela" for="age">{{ godinePitanje }}</label>
          <input type="number" id="age" v-model="form.age" required>
        </div>

        <div class="form-group">
          <label for="weight">{{ weightPitanje }}</label>
          <input type="number" id="weight" v-model="form.weight" required>
        </div>

        <div class="form-group">
          <label for="height">{{ heightPitanje }}</label>
          <input type="number" id="height" v-model="form.height" required>
        </div>

        
        <div class="form-group">
          <label for="gender">{{ genderPitanje }}</label>
          <select id="gender" v-model="form.gender" required>
            <option value="muski">Muski</option>
            <option value="zenski">Zenski</option>
          </select>
        </div>

        <div class="form-group">
          <label for="fitnessLevel">{{ fitnessLevelPitanje }}</label>
          <select id="fitnessLevel" v-model="form.fitnessLevel" required>
            <option value="početnik">Početnik (0-1 godine aktivnog treniranja)</option>
            <option value="srednji">Srednji (2-5 godine aktivnog treninga)</option>
            <option value="napredni">Napredni (5+ godina aktivnog treniranja)</option>
          </select>
        </div>

        <button type="button" @click="nextStep">Dalje</button>
      </div>

      <!-- Druga faza pitanja -->
      <div v-if="currentStep === 2">
        <div class="form-group">
          <label for="goals">{{ goalsPitanje }}</label>
          <input type="text" id="goals" v-model="form.goals" required>
        </div>

        <div class="form-group">
          <label for="trainingFrequency">{{ trainingFrequencyPitanje }}</label>
          <input type="number" id="trainingFrequency" v-model="form.trainingFrequency" required>
        </div>

        <div class="form-group">
          <label for="trainingDuration">{{ trainingDurationPitanje }}</label>
          <input type="range" id="trainingDuration" v-model="form.trainingDuration" min="30" max="180" step="10">
          <span>{{ form.trainingDuration }} minuta</span>
        </div>

        <div class="form-group">
          <label for="trainingPreference">{{ trainingPreferencePitanje }}</label>
          <input type="text" id="trainingPreference" v-model="form.trainingPreference" required>
        </div>

        <div class="form-group">
          <label for="favoriteExercises">{{ favoriteExercisesPitanje }}</label>
          <input type="text" id="favoriteExercises" v-model="form.favoriteExercises" required>
        </div>

        <div class="form-group">
          <label for="dislikedExercises">{{ dislikedExercisesPitanje }}</label>
          <input type="text" id="dislikedExercises" v-model="form.dislikedExercises" required>
        </div>

        <button type="button" @click="nextStep">Dalje</button>
      </div>

      <!-- Treća faza pitanja -->
      <div v-if="currentStep === 3">
        <div class="form-group">
          <label for="injuries">{{ injuriesPitanje }}</label>
          <input type="text" id="injuries" v-model="form.injuries" required>
        </div>

        <div class="form-group">
          <label for="favoriteBodyParts">{{ favoriteBodyPartsPitanje }}</label>
          <input type="text" id="favoriteBodyParts" v-model="form.favoriteBodyParts" required>
        </div>

        <div class="form-group">
          <label for="includeCardio">{{ includeCardioPitanje }}</label>
          <input type="text" id="includeCardio" v-model="form.includeCardio" required>
        </div>

        <div class="form-group">
          <label for="otherFactors">{{ otherFactorsPitanje }}</label>
          <input type="text" id="otherFactors" v-model="form.otherFactors" required>
        </div>

        <button type="submit">Pošalji</button>
      </div>
    </form>
    <div v-if="currentStep === 4">
      <div>
        <p :style="{ 'white-space': 'pre-line' }">{{ plan }}</p>
      </div>
    </div>
  </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { posaljiPitanje } from '../services/ChatGPTService';

const currentStep = ref(1);

const genderPitanje = ref('Kog ste\n pola?');
const godinePitanje = ref("Koliko godina imate?");
const fitnessLevelPitanje = ref("Koji je vaš trenutni nivo fizičke spremnosti (početnik, srednji, napredni)?");
const goalsPitanje = ref("Koji su vaši glavni ciljevi vezani za trening (snaga, povecanje misicne mase, postizanje zategnutosti, kondicija, mršavljenje, fleksibilnost)?");
const trainingFrequencyPitanje = ref("Koliko puta nedeljno možete trenirati?");
const trainingDurationPitanje = ref("Koliko bi voleli da vam trening traje vremenski?");
const trainingPreferencePitanje = ref("Da li imate preferenciju za određeni tip treninga (snaga, kondicija, HIIT, bodybuilding)?");
const favoriteExercisesPitanje = ref("Imate li omiljene vežbe koje volite?");
const dislikedExercisesPitanje = ref("Imate li vežbe koje ne volite?");
const injuriesPitanje = ref("Da li imate povrede ili ograničenja koje treba uzeti u obzir?");
const favoriteBodyPartsPitanje = ref("Imate li omiljene partije tela koje želite da razvijete?");
const includeCardioPitanje = ref("Da li želite da uključite kardio trening u plan? Ako da, koliko često?");
const weightPitanje = ref("Koja je vaša trenutna telesna težina?");
const heightPitanje = ref("Koja je vaša visina?");
const otherFactorsPitanje = ref("Postoji li neki drugi faktor koji smatrate bitnim za kreiranje plana?");

const form = ref({
  age: '',
  gender: '',
  fitnessLevel: '',
  goals: '',
  trainingFrequency: '',
  trainingPreference: '',
  trainingDuration: '',
  favoriteExercises: '',
  dislikedExercises: '',
  injuries: '',
  favoriteBodyParts: '',
  includeCardio: '',
  weight: '',
  height: '',
  otherFactors: ''
});

const nextStep = () => {
  if (currentStep.value < 4) {
    currentStep.value++;
  }/*
  else {
    if(currentStep.value === 3) {
    currentStep.value++;
    }
  }*/
};


let prompt = ref('');

const createPrompt = () => {
  prompt.value = `
  Zanemari sve sto sam ti do sad slao.
  Na osnovu sledećih korisničkih unosa, kreiraj detaljan i personalizovan plan treninga na srpskom jeziku (ekavici). Plan treba da se temelji na najnovijim saznanjima iz oblasti treninga za hipertrofiju, snagu, mobilnost i opšte kondicije, uzimajući u obzir relevantnu svetsku literaturu kao što su NSCA, ACSM i druge priznate izvore iz nauke o vežbanju. U planu primeni principe progresivnog opterećenja, funkcionalnog treninga i poboljšanja mobilnosti, uz prilagođavanje volumena, intenziteta i izbora vežbi prema individualnim korisničkim odgovorima.

Plan treba da uključuje detaljna uputstva za svaku vežbu, preporuke za odmor između serija, protokole za zagrevanje, kao i savete za oporavak, uzimajući u obzir nivo iskustva korisnika, ciljeve i eventualna ograničenja. Trening program treba da adresira različite podele treninga (npr. push-pull-legs, upper-lower ili full-body), i da bude prilagođen za optimalne performanse, dugovečnost i prevenciju povreda. Takođe, dodaj i nutricionističke smernice koje će podržati korisnikove ciljeve, uzimajući u obzir potrebe za makronutrijentima i vremensku usklađenost obroka s nivoom aktivnosti. 
  Forma: ${godinePitanje.value} ${form.value.age}, 
         ${fitnessLevelPitanje.value} ${form.value.fitnessLevel}( od odvoga zavisi koliko ce kompleksan plan da bude ), 
         ${goalsPitanje.value} ${form.value.goals}, 
         ${genderPitanje.value} ${form.value.gender} (u zavisnosti od ovog odgovora modelujes plan tako da kod zena veci deo bude na donjem delu tela(znaci za zene uglavnom biras Upper Lower split sa tim da Lower ima fokus na gluteus(hip thrust da bude prva i najbitnija vezba)), a za muskarce se na leg day-u vise fokusiras na cucanj i po potrebi mrtvo dizanje, bez hip thrusta kod muskaraca) , 
         ${trainingFrequencyPitanje.value} ${form.value.trainingFrequency} (od ovoga zavisi koliko ces mu dana za trening dati npr. ako stavi 4 stavices Day1 Day2 Day3 i Day4. Takodje, u zavisnosti od ovoga biras i strukturu plana, da li ce biti Push Pull Legs(3 dana), Upper Lower (4 dana), Arnold Split(4 dana), grudi i triceps ledja i biceps noge ramena ruke i grudi ledja(5) , full Body itd. ) , 
         ${trainingDurationPitanje.value} ${form.value.trainingDuration} (u zavisnosti od ovog odgovora biras broj vezbi i serija koje treba da se odrade u treningu. U to vreme ne racunas zagrevanje vec samo vezbe. Izracunaj otprilike koliko vremena bi mi trebalo za koju vezbu i tako proceni koliko treba vezbi i serija. Za teze vezbe kao sto su Cucanj, Bench, Mrtvo itd stavljas vece pauze i vise vremena, a za one lakse vezbe stavljas manje pauze.), 
         ${trainingPreferencePitanje.value} ${form.value.trainingPreference}, 
         ${favoriteExercisesPitanje.value} ${form.value.favoriteExercises} (ubaci ovu/e vezbu/e prilikom kreiranja plana) ,   
         ${dislikedExercisesPitanje.value} ${form.value.dislikedExercises} (izbaci ovu/e vezbu/e prilikom kreiranja plana) , 
         ${injuriesPitanje.value} ${form.value.injuries} (pripazi na vezbe i pokrete koji ukljucuju povredjen deo ukoliko ga ima) ,   
         ${favoriteBodyPartsPitanje.value} ${form.value.favoriteBodyParts} (prilikom kreiranja baci fokus nadeo koji korisnik zeli najvise da razvije ukoliko ga ima) , 
         ${includeCardioPitanje.value} ${form.value.includeCardio}, 
         ${weightPitanje.value} ${form.value.weight}, 
         ${heightPitanje.value} ${form.value.height}, 
         ${otherFactorsPitanje.value} ${form.value.otherFactors}.\n
         Kraj forme.\n
         Takodje, na osnovu tezine, visine, spremnosti i aktivnosti, proceni koliko bi osoba trebala da unosi kalorija i proteina i daj joj smernice i preporuke vezane za ishranu. 
         Odgovor treba da mi podelis na tri sekcije i ne smes nista vise da ubacujes van toga. Prva sekcija je objasnjenje plana, Druga sam plan sa vezbama i brojevima serija i ponavlajanja (u formi Dan1:Vezba1-BrSerijaxBrPonavljanja...) i treca smernice za ishranu, ne treba da mi vracas opet formu ili nesto slicno, vec samo da das odgovor. Nemoj da stavljas brojeve 1 2 i 3 za delove vec ih samo odvoj po pasusima.
         NEMOJ da pises prva sekcija, druga sekcija, treca sekcija vec samo razdvoji po pasusima.
         Prilikom kreiranja plana postuj ovih 50 pravila:"1-10: Razumevanje ciljeva klijenta
Definiši ciljeve klijenta: Jasno identifikuj da li je cilj mršavljenje, povećanje snage, hipertrofija, poboljšanje kondicije, ili kombinacija više ciljeva.
Postavi realna očekivanja: Uveri se da ciljevi mogu biti postignuti u razumljivom vremenskom okviru, izbegavaj nerealna obećanja.
Praćenje napretka: Redovno meri rezultate kako bi klijent video napredak i prilagođavao program.
Upoznaj klijentovu trenutnu kondiciju: Procenom početne kondicije možeš prilagoditi trening plan prema potrebama klijenta.
Razlikuj početnike i iskusne vežbače: Početnici imaju bržu adaptaciju i mogu izdržati manje volumena, dok iskusniji trebaju složenije programe.
Razmatraj povrede i ograničenja: Prilagodi vežbe kako bi izbegao povrede, a istovremeno omogućio napredak.
Postavi male ciljeve na putu ka većem cilju: Koraci ka glavnom cilju motivišu klijente i održavaju ih fokusiranim.
Osobeni stil treniranja: Razumi šta klijentu više odgovara – rad s tegovima, vežbe snage, kardio – i prilagodi program njegovim preferencijama.
Mentalna priprema je ključna: Podstakni klijente da razviju pozitivan stav i izgrade samopouzdanje.
Fokus na dugoročnu održivost: Kreiraj plan koji se može dugoročno pratiti, a ne ekstremne kratkoročne programe.
11-20: Osnove periodizacije i treninga
Koristi periodizaciju: Deljenje trening programa u cikluse (snaga, hipertrofija, izdržljivost) omogućava kontinuiran napredak i izbegava stagnaciju.
Linearno povećanje opterećenja: Postepeno povećavaj težine ili broj ponavljanja, kako bi izbegao stagnaciju.
Uključi različite tipove treninga: Kombinuj snagu, hipertrofiju, i kondiciju u različitim fazama treninga.
Ne zaboravi na deload faze: U program ubaci lakše nedelje da bi se telo oporavilo i sprečilo pretreniranost.
Fokus na osnovne vežbe: Složenije vežbe, kao što su čučanj, mrtvo dizanje i benč pres, aktiviraju više mišićnih grupa i daju bolje rezultate.
Raznovrsnost vežbi: Promeni vežbe svakih nekoliko nedelja kako bi izazvao telo i sprečio dosadu.
Treniraj specifičnost cilja: Ako je cilj snaga, naglasi vežbe sa težim opterećenjima; ako je cilj hipertrofija, fokusiraj se na vežbe sa višim ponavljanjima.
Prilagodi volumen i intenzitet: Na osnovu iskustva klijenta, povećaj ili smanji broj serija i težinu.
Prati progresivne principe treninga: Bez progresivnog povećanja opterećenja neće biti napretka.
Nemoj preterivati sa kardio treningom ako je cilj hipertrofija: Previše kardio treninga može usporiti rast mišića.
21-30: Praktični treninzi i tehnike
Tehnika pre težine: Uvek se pobrini da klijent prvo savlada tehniku pre nego što poveća težinu.
Ispravno postavi telo: Držanje je ključno za sve vežbe kako bi se izbegle povrede.
Kreiraj balans između snage i izdržljivosti: Uvek uključi i vežbe snage i vežbe izdržljivosti.
Koristi super setove za efikasnost: Kombinuj vežbe koje ciljaju različite mišićne grupe kako bi povećao intenzitet bez povećanja vremena treninga.
Koristi povremeno vežbe na mašinama: Mašine mogu pomoći u izolaciji mišićnih grupa i obezbediti sigurniji pokret.
Tempo vežbanja: Vreme pod naponom (tempo) igra ključnu ulogu u razvoju mišića – usporavanje ekscentrične faze vežbanja može povećati hipertrofiju.
Dajte prioritet slabostima: Uvek prvo radite na slabijim delovima tela kako biste izbegli neravnoteže.
Dinamika zagrevanja i hlađenja: Dobro zagrevanje smanjuje rizik od povrede, dok hlađenje pomaže oporavku.
Primenjuj pravilne intervale odmora: Prilagodi odmore između serija – kraći odmori za izdržljivost, duži za snagu.
Prati ravnotežu mišića: Uvezi i prednje i zadnje mišiće, kako bi održao ravnotežu i sprečio povrede.
31-40: Planiranje ishrane i oporavak
Prati unos kalorija: Uveri se da ishrana klijenta podržava ciljeve treninga.
Održavaj balans makronutrijenata: Unos proteina, ugljenih hidrata i masti mora biti u skladu sa ciljevima klijenta.
Unos proteina: Preporuči dovoljno proteina (oko 1.6-2.2g po kilogramu telesne mase) za rast mišića.
Važnost hidratacije: Uvek naglasi važnost hidratacije tokom treninga.
Praćenje unosa hrane: Uči klijente da beleže šta jedu kako bi lakše prilagodili plan ishrane.
Dani odmora: Oporavak je ključan za rast mišića, stoga uvek planiraj dovoljno dana odmora.
Spavanje je ključno: Optimalno vreme za spavanje je važno za oporavak i rezultate.
Suplementacija kao dodatak, a ne zamena: Kreatin, proteini i multivitamini mogu pomoći, ali nisu zamena za dobru ishranu.
Planiraj kalorijski unos prema cilju: Za mršavljenje, stvori deficit, a za hipertrofiju blag kalorijski suficit.
Pravilno tempiranje obroka: Unos ugljenih hidrata i proteina pre i posle treninga može optimizovati performanse i oporavak.
41-50: Personalizacija plana i motivacija
Prilagodi plan prema ličnosti klijenta: Neki klijenti vole strukturirane planove, dok drugi preferiraju veću fleksibilnost.
Motiviši klijente postavljanjem izazova: Dodaj male izazove kako bi motivisao klijente i održao njihov entuzijazam.
Praćenje motivacije: Prati emocionalno stanje klijenta i prilagodi trening kada uočiš da je potrebno.
Fokusiraj se na dugoročnu progresiju: Program treba da bude održiv i dugoročan, a ne ekstreman.
Održavaj varijaciju vežbi: Menjanje vežbi pomaže u sprečavanju dosade i osigurava napredak.
Uključi povremene testove snage i izdržljivosti: Ovi testovi pokazuju klijentu napredak i motivišu ga da nastavi.
Komuniciraj redovno s klijentom: Redovni razgovori mogu pomoći u razumevanju njihovih osećanja o treningu i učiniti program efikasnijim.
Uključi dane za povremeno testiranje limita: Pomozi klijentu da vidi koliko je napredovao.
Pazi na pretreniranost: Ako klijent postane previše iscrpljen, smanji intenzitet ili obim kako bi se telo oporavilo.
Prilagođavaj program kako klijent napreduje: Stalno evaluiraj i menjaš plan u skladu s klijentovim napretkom i promenama u ciljevima."
         `//Plan daj u formatu stringa, tako da se lepo ispise na ekranu.To znaci da treba da koristis backslash+n (samo spojeno) na kraju svakog paragrafa.
        
         //`//OBAVEZNO:Samo mi daj za odredjeni broj treninga nedeljno podeljeno u formatu Dan1:NazivVezbe-SerijaxPonavljanja; kraj dana oznaci sa '%'(npr. Day1:Squat-4x10;Lunges-3x12...%Day2:...) i nemoj nikakav dodatni tekst da dodajes. Obavezno daj odgovor u formatu koji je zatrazen van forme.`;

  alert(prompt.value);
};

const plan = ref('Plan is currently loading...');

const handleSubmit = () => {
alert('Forma je poslata');
createPrompt();
posaljiPitanje(prompt.value).then(odgovor => {
  alert(odgovor); // Prikazuje odgovor
  plan.value = odgovor;
});
nextStep();
};
</script>
<style scoped>

html, body {
  margin: 0;
  padding: 0;
  height: 100%; /* Osiguraj da HTML i body zauzimaju 100% visine */
}

.background-image {
  position: absolute;
  top: 0;
  left: 0;
  width: 100vw;
  min-height: 150vh;
}


.form-container {
  max-width: 600px;
  margin: 0 auto;
  padding: 1em;
  border: 1px solid #333;
  border-radius: 8px;
  background-color: rgba(51, 51, 51); /* Smanjena prozirnost za efekat na tamnoj pozadini */
  color: #fff;
  margin-top: 75px; /* Povećaj vrednost kako bi pomerio formu ka dole */
  position: relative;
}

.form-group {
  margin-bottom: 1em;
}

label {
  margin-bottom: 0.5em;
  color: #fff;
  display: block;
}

input[type="text"], input[type="number"], select, input[type="range"] {
  border: 1px solid #777;
  padding: 0.5em;
  border-radius: 4px;
  width: 100%;
  background-color: #555;
  color: #fff;
}

button {
  background-color: #444;
  color: #fff;
  border: none;
  padding: 0.5em 1em;
  border-radius: 4px;
  cursor: pointer;
}

button:hover {
  background-color: #222;
}
</style>
