# CentricExpress2021-.NET

In urmatorii pasi vom presenta o arhitectura, pattern-uri si cateva practici aplicate in solutia noastra.

## Partea 1 - Arhitectura (Layered Architecture)
In primul rand vom incepe cu baza codului (**step1 branch**) pe care vom incepe sa construim arhitectura aplicatiei. Vom folosi **Layered Architecture** pentru solutia noastra.

### Pasul 1 - Proiectele
In acest pas definim structura solutiei. Trebuie sa adaugam un proiect pentru fiecare layer.
Din **step1 branch** observam ca avem deja definit proiectul **Flights.WebApi**, acesta face parte din **Presetantion Layer**.
Prin urmare trebuie sa adaugam alte 2 proeicte de tip **Class Library (.NET Core)**:
    - **Flights.Business** (Business Layer)
    - **Flights.Data** (Persistence Layer)

### Pasul 2 - Dependinte
  Vom adauga dependintele urmatoare:
    - Fligts.WebApi - **referinta la** -> Flights.Business
    - Fligts.Business - **referinta la** -> Flights.Data
  
  
## Partea 2 - CRUD

### Pasul 1 - Persistence Layer
  Vom incepe prin a crea entitatile necesare in proiectul Flights.Data:
    - **Flight**
    - **Reservation**
 Tot in proiectul Flights.Data vom crea clasa **Database** pentru a servi ca o baza de date statica.
 
 
 
 ### Pasul 2 - Business Layer
  Adaugam modelele DTO in proiectul Flights.Business. Aceste modele vor fi folosite pentru a returna un raspuns utilizatorului.
    - **FlightDto**
    - **ReservationDto**
  
  Acum avem nevoie de 2 interfete in care o sa adaugam ce metode avem nevoie sa implementam(CRUD).
    -**IReservetionBusiness**
    -**IFlightBusiness**
  
  Adaugam 2 clase unde vom implementa metodele definite in interfete.
    - **ReservationBusiness** implementeaza IReservationBusiness
    - **FlightBusiness** implementeaza IFlightBusiness

  
 ### Pasul 3 - Presetantion Layer
  Deoarece dorim sa folosim DI (**Dependecy Injection**), primul lucru pe care il vom face in acest proiect este sa comfiguram asta. Mergem in fisierul Startup.cs, iar in metoda ConfigureServices vom adauga urmatoarele linii:
            **services.AddSingleton<IReservationBusiness, ReservationBusiness>();**
            **services.AddSingleton<IFlightBusiness, FlightBusiness>();**
            
  Vom adauga in proiect 2 clase pe care le vom folosi ca si Controlere.
    - **ReservationController**
    - **FlightController**

  In fiecare din clase vom injecta serviciul dorit (IReservationBusiness sau IFlightBusiness) folosind constructorul. Urmand sa adaugam metodele HTTP necesare pentru CRUD:
    - **HttpPost** 
    - **HttpGet** 
    - **HttpPut**
    - **HttpDelete**
  


  
  
  
  
  

