# CentricExpress2021-.NET
Pentru a configura si interactiona cu baza de date s-au urmarit urmatorii pasi:

Instalare library necesare Accesati Tools -> NuGet Package Manager -> Manage NuGet Packages For Solution Cautati Microsoft.EntityFramework si instalați următoarele pachete in proiectul Movies.Data: 
• Microsoft.EntityFrameworkCore 
• Microsoft.EntityFrameworkCore.SqlServer(pentru provider) 
• Microsoft.EntityFrameworkCore.Tools(pentru a executa comenzi) 
• Microsoft.EntityFrameworkCore.Design(pentru a activa interactiuni la design-time: migrations )

Creare context

Redenumim Database.cs -> DatabaseContexts.cs
Derivam DatabaseContext din DbContext
Adăugam o proprietate DbSet pentru entitatile Flight Reservation si anume: public DbSet Movies { get; set; } public DbSet Reservations { get; set; }
Pentru a avea date initiale am transferat lista statica de zboruri entitatii din context folodind metoda .HasData()
Creare ContextFactory derivat din IDesignTimeDbContextFactory pentru a activa servicii la design-time, in cazul de fata necesar pentru a activa migrarea schimbărilor la baza de date - Migrations
Conectare provider In Startup.cs înregistram contextul creat cu configurările necesare, specificând provider-ul si connection string-ul. Vom defini configurările cu ajutorul DbContextOptionsBuilder, pentru o baza de date SQL Server folosi metoda .UseSqlServer().

Configurare Model folosind DataAnnotations In Flight.cs si Reservation.cs adăugam atributul [Key] pentru proprietatea Id pentru a specifica cheia primara a tabelei si atributul [DatabaseGenerated] pentru ca valoare sa sa fie generata. Alte atribute folosite ar putea fi: ColumnName, Type, MaxLenght, etc. mai multe exemple de atribute se găsesc aici: https://www.entityframeworktutorial.net/code-first/dataannotation-in-code-first.aspx

Adaugam prima migrare la baza de date:
a. Deschidem Package Manager Console 
b. Rulam add-migration CreateDatabase, sau orice alt nume pentru migrare, dar trebuie sa fie sugestiv (ne asiguram ca proiectul Movies.Data este setat ca Start up project) 
c. Rulam update-database.
Apoi verificam in Sql MAnager ca baza de date s-a creat cu success.
Accesand swagger putem verifica conexiunea la baza de date: rulam applicatia si accesam ' /swagger '.

Creare repository

Cream MovieRepository si injectam DatabaseContext in constructor
Cream o metoda Get care returnează toata lista de filme din baza de date
Se apeleaza contextul astfel: _dbContext.Set().AsEnumerable();
Adaugam si medoda de add care adauga un film in baza de date. Cand se executa comenzi trebuie sa tinem minte sa apelam si SaveChanges pe context.
Aplicare schimbări

Modificam in layerul de business sa folosească repository-ul nou creat, respectiv sa foloseasca o conexiune la baza de date.
Accesand swagger putem verifica conexiunea la baza de date: rulam applicatia si accesam ' /swagger '.
