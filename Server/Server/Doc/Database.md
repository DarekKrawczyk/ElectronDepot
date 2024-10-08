# RestAPI - documentation
## Database
![Database diagram](DBDiagram.svg)
## Tabela `users` (Użytkownicy)
Przechowuje dane o zarejestrowanych użytkownikach.

| Kolumna       | Typ         | Opis                                |
|---------------|-------------|-------------------------------------|
| `UserID`      | INT (PK)    | Unikalny identyfikator użytkownika  |
| `Username`    | VARCHAR(100)| Login użytkownika                   |
| `Password`    | VARCHAR(255)| Hasło                               |
| `Email`       | VARCHAR(255)| Adres email                         |

## Tabela `components` (Komponenty)
Przechowuje informacje o układach scalonych i innych elementach elektronicznych.

| Kolumna        | Typ           | Opis                                 |
|----------------|---------------|--------------------------------------|
| `ComponentID`  | INT (PK)      | Unikalny identyfikator komponentu    |
| `UserID`       | INT (FK)      | ID użytkownika, właściciela komponentu|
| `Name`         | VARCHAR(255)  | Nazwa komponentu                     |
| `Manufacturer` | VARCHAR(255)  | Producent                            |
| `CategoryID`   | INT (FK)      | ID kategorii z tabeli `categories`   |
| `Description`  | TEXT          | Opis komponentu                      |
| `Quantity`     | INT           | Ilość dostępnych sztuk               |
| `Location`     | VARCHAR(255)  | Gdzie przechowywany (np. szafka A)   |
| `CreatedAt`    | TIMESTAMP     | Data dodania komponentu              |

## Tabela `categories` (Kategorie komponentów)
Zawiera predefiniowane kategorie dla komponentów elektronicznych.

| Kolumna       | Typ           | Opis                                  |
|---------------|---------------|---------------------------------------|
| `CategoryID`  | INT (PK)      | Unikalny identyfikator kategorii       |
| `Name`        | VARCHAR(100)  | Nazwa kategorii (np. IC, Resistors)    |
| `Description` | VARCHAR(255)  | Opcjonalny opis kategorii              |

## Tabela `projects` (Projekty)
Przechowuje informacje o projektach użytkownika.

| Kolumna      | Typ          | Opis                                 |
|--------------|--------------|--------------------------------------|
| `ProjectID`  | INT (PK)     | Unikalny identyfikator projektu      |
| `UserID`     | INT (FK)     | ID użytkownika, właściciela projektu |
| `Name`       | VARCHAR(255) | Nazwa projektu                       |
| `Description`| TEXT         | Opis projektu                        |
| `CreatedAt`  | TIMESTAMP    | Data utworzenia projektu             |

## Tabela `component_project` (Przypisanie komponentów do projektów)
Relacja wiele-do-wielu pomiędzy komponentami a projektami.

| Kolumna         | Typ         | Opis                                |
|-----------------|-------------|-------------------------------------|
| `ComponentID`  | INT (FK)    | ID komponentu                       |
| `ProjectID`    | INT (FK)    | ID projektu                         |
| `QuantityUsed` | INT         | Ilość użytych sztuk komponentu      |

## Tabela `purchases` (Zakupy)
Przechowuje informacje o zakupach komponentów zintegrowanych z e-mailami i sklepami.

| Kolumna        | Typ           | Opis                                 |
|----------------|---------------|--------------------------------------|
| `PurchaseID`   | INT (PK)      | Unikalny identyfikator zakupu        |
| `UserID`       | INT (FK)      | ID użytkownika, który dokonał zakupu |
| `SupplierID`   | INT (FK)      | ID dostawcy/sklepu                   |
| `PurchaseDate` | TIMESTAMP     | Data zakupu                          |
| `TotalPrice`   | DECIMAL(10, 2)| Całkowita cena zakupu                |

## Tabela `purchase_items` (Szczegóły zakupu)
Przechowuje informacje o komponentach wchodzących w skład konkretnego zakupu.

| Kolumna         | Typ           | Opis                                |
|-----------------|---------------|-------------------------------------|
| `PurchaseItemID`| INT (PK)      | Unikalny identyfikator wiersza      |
| `PurchaseID`    | INT (FK)      | ID zakupu                           |
| `ComponentID`   | INT (FK)      | ID komponentu                       |
| `Quantity`      | INT           | Ilość zakupionych sztuk             |
| `PricePerUnit`  | DECIMAL(10, 2)| Cena za jednostkę                   |

## Tabela `suppliers` (Dostawcy/Sklepy)
Przechowuje dane o sklepach, z których mogą pochodzić komponenty.

| Kolumna      | Typ           | Opis                                 |
|--------------|---------------|--------------------------------------|
| `SupplierID` | INT (PK)      | Unikalny identyfikator dostawcy/sklepu|
| `Name`       | VARCHAR(255)  | Nazwa sklepu (np. Allegro, Botland)  |
| `Website`    | VARCHAR(255)  | Strona internetowa sklepu            |

## Relacje pomiędzy tabelami:
- **Jeden do wielu** między tabelą `users` a tabelami `components`, `projects`, `purchases` (użytkownik może mieć wiele komponentów, projektów, zakupów).
- **Wiele do wielu** między tabelami `components` a `projects` (komponenty mogą być używane w wielu projektach i projekty mogą używać wielu komponentów).
- **Jeden do wielu** między tabelą `purchases` a tabelą `purchase_items` (zakup może obejmować wiele komponentów).
- **Jeden do wielu** między tabelą `suppliers` a tabelą `purchases` (dostawca może być powiązany z wieloma zakupami).