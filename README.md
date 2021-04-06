# CentricExpress2021-.NET

## Basic API Setup 
In acest pas am facut urmatoarele:
1. am creat o solutie noua, cu un proiect de tip WebAPI
2. am creat doua controller-e, cu metode de baza pe o lista statica

### Solutia noua
- in Visual Studio, cream o solutie noua: File -> New -> Project -> alegem Blank Solution si ii dam un nume sugestiv (`Flights`)
- adaugam un nou proiect in solutie: click dreapta pe solutie (in Solution Explorer) -> Add -> New Project -> alegem ca template **ASP.NET Core Web Application** cu numele `Flights.WebApi` -> alegem template-ul API

### Controller cu functionalitate de baza
 - adaugam un **model pentru Flight**: click dreapta pe proiectul creat anterior -> Add -> New folder -> numim folderul Models
   - click dreapta pe folderul Models -> Add -> Class si ii punem numele `Flight`
   - adaugam proprietatile unui film in clasa `Flight.cs` (Id, PlaneModel, DepartureTime, ArrivalTime...)
- adaugam un controller pentru zboruri
    - click dreapta pe folderul Controllers -> Add -> Controller -> Alegem API Controller-Empty si il numim `FlightsController`
    - adaugam o lista de zboruri pe care le putem returna, deoarece inca nu avem conexiune la baza de date
- adaugam o metoda **Get** pe care punem adnotarea `[HttpGet]` - pentru a returna zborurile
- adaugam o metoda **Create** pe care punem adnotarea `[HttpPost]` - pentru a adauga un zbor nou

#### Swagger UI

Pentru a vizualiza mai usor API-ul, folosim Swagger UI.
- click dreapta pe proiect -> Manage nuget packages -> instalam **Swashbuckle.AspNetCore**.

- in Startup.cs inregistram swagger in servicii:

        services.AddSwaggerGen(s =>
        {
          s.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); 
        });	
- in Startup configuram swagger:

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
