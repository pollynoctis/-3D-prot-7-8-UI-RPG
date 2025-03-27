# -3D-prot-7-8-UI-RPG
Šis ir neliels UI RPG projekts, taisīts universitātei. Gameplay ir vienkārš: spēlētāja mērķis ir uzvarēt 3 enemies, izdzīvojot. Spēlētājs var uzbrukt, izmantot vairogu vai uzārstēties.


imzantotie OOP principi un to apraksts
Enkapsulācija - health variable ir privāts, tādēļ tiek izmantots get un set, lai tas būtu accesible no citiem skriptiem. 
overload - projektā ir funkcija GetHit, un atkarībā no situācijas tiek izmantots GetHit ar int vai GetHit ar weapon.
mantošana - projektā ir virsklase Character, no kuras klase enemy un no tās ir izveidotas 3 papildus klases: bonnie, foxy un freddy. Character klasei ir vairākas metodes un variables, kas tiek mantotas pārējos skriptos
abstrakcija - projektā ir abstrakta klase Weapon, no kuras manto citi skripti. Katrs Weapon klases skripts ir unikāls. 


Projekta mehānikas:
Spēlētājam tiek piedāvātas 3 pogas: uzbrukt, izmantot vairogu vai uzārstēties. 
Atkarībā no spēlētāja veiksmes, vairogs var salūzt. Vēlāk vairogs tiek atgūts un spēlētājs var to izmantot vēlreiz. Vairoga mērķis ir samazināt iegūto damage uz pusi. 
Kad spēlētājs izmanto uzārstēšanos, viņam ir jāgaida noteikts laiks, pirms drīkstēs atkal ārstēties. Ja spēlētājam ir zem 50 dzīvībām, ārstēšanās būs efektīvāka. 
Projektā ir 3 enemies, kas iet pēc kārtas:
- Bonnie. Viņam ir iespēja uzārstēties, atgūstot 5 dzīvības.
- Foxy. Viņam ir iespēja iedot ekstra stipru sitienu spēlētājam.
- Freddy. Ar katru gājienu Freddy kļūst agresīvāks un viņa damage palielinās.

Kad spēlētājs nogalina visus enemies, viņš vinnē. Nogalinot vienu enemy, spēlētāja veselība atgriežas uz sākotnējo. Ja spēlētājs zaudē dzīvības, spēle beidzas. 

