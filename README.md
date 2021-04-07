# CentricExpress2021-.NET
Pentru a configura si interactiona cu baza de date s-au urmarit urmatorii pasi:

## 1.Instalare library necesare 
  Accesati Tools -> NuGet Package Manager -> Manage NuGet Packages For Solution Cautati Microsoft.EntityFramework si instalați următoarele pachete in proiectul Flights.Data: 
* Microsoft.EntityFrameworkCore 
* Microsoft.EntityFrameworkCore.SqlServer(pentru provider) 
* Microsoft.EntityFrameworkCore.Tools(pentru a executa comenzi) 
* Microsoft.EntityFrameworkCore.Design(pentru a activa interactiuni la design-time: migrations ) (si in Flights.WebApi)

## 2.Creare context
 * Redenumim Database.cs -> DatabaseContexts.cs
 * Derivam DatabaseContext din DbContext
 * Adăugam o proprietate DbSet pentru entitatile Flight si Reservation si anume: *public DbSet Fights { get; set; } public DbSet Reservations { get; set; }*
 * Pentru a avea date initiale am transferat lista statica de zboruri entitatii din context folodind metoda .HasData()

 ## 3.Conectare provider 
  In Startup.cs înregistram contextul creat cu configurările necesare, specificând provider-ul si connection string-ul. Vom defini configurările cu ajutorul DbContextOptionsBuilder, pentru o baza de date SQL Server folosi metoda .UseSqlServer().

Configurare Model folosind DataAnnotations In Flight.cs si Reservation.cs adăugam atributul [Key] pentru proprietatea Id pentru a specifica cheia primara a tabelei si atributul [DatabaseGenerated] pentru ca valoare sa sa fie generata. Alte atribute folosite ar putea fi: ColumnName, Type, MaxLenght, etc. mai multe exemple de atribute se găsesc aici: https://www.entityframeworktutorial.net/code-first/dataannotation-in-code-first.aspx

## 4.Adaugam prima migrare la baza de date:
 * Deschidem Package Manager Console (*Tools -> Nuget Package Manager -> Package Manager Console*)
 * Rulam add-migration CreateDatabase, sau orice alt nume pentru migrare, dar trebuie sa fie sugestiv (ne asiguram ca proiectul Flights.Data este setat ca Start up project) 
 * Rulam update-database.
Apoi verificam in Sql Manager ca baza de date s-a creat cu success.
Accesand swagger putem verifica conexiunea la baza de date: rulam applicatia si accesam ' /swagger '.

## 5.Creare repository
 * Cream FlightRepository si injectam DatabaseContext in constructor
 * Cream o metoda Get care returnează toata lista de zboruri din baza de date
 * Se apeleaza contextul astfel: _dbContext.Set().AsEnumerable();
 * Adaugam si medoda de add care adauga un zbor in baza de date, edit pentru editarea unui zbor si alte metode de care avem nevoie in applicatia noastra. 
 Cand se executa comenzi trebuie sa tinem minte sa apelam si SaveChanges pe context.
 Aplicare schimbări
 La fel procedam si pentru Reservations.

## 6.Modificam in layerul de business sa folosească repository-ul nou creat respectiv.
 * Injectam repository-ul in locul Contextului
 * Apelam metodele din repository
 
Accesand swagger putem verifica conexiunea la baza de date: rulam applicatia si accesam ' /swagger '.
