Step 2 - Architecture

In urmatorii pasi vom presenta o arhitectura, pattern-uri si cateva practici aplicate in solutia noastra.

Cap 1 - Arhitectura (Layered Architecture)
In primul rand vom incepe cu baza codului (step1 branch) pe care vom incepe sa construim arhitectura aplicatiei. Vom folosi Layered Architecture pentru solutia noastra.

Pasul 1 - Proiectele
In primul rand vom incepe cu baza codului (step1 branch) pe care vom incepe sa construim arhitectura aplicatiei. Vom folosi Layered Architecture pentru solutia noastra.

  In acest pas definim structura solutiei. Trebuie sa adaugam un proiect pentru fiecare layer.
  Din step1 branch observam ca avem deja definit proiectul Flights.WebApi, acesta face parte din Presetantion Layer.
  Prin urmare trebuie sa adaugam alte 2 proeicte (tip Class Library):
    - Flights.Business (Business Layer)
    - Flights.Data (Persistence Layer)

Pasul 2 - Dependinte
  Vom adauga dependintele urmatoare:
    - Fligts.WebApi - referinta la -> Flights.Business
    - Fligts.Business - referinta la -> Flights.Data
  
  
Cap 2 - Patterns and Practices

Pasul 1 - Entitatile
  Vom incepe prin a crea entitatile necesare in proiectul Flights.Data:
    - Flight
    - Reservation
 Tot in proiectul Flights.Data vom crea clasa Database pentru a servi ca o baza de date statica.
 
 Pasul 2 - 




# CentricExpress2021-.NET
