# ElectronDepot

## Idea projektu:
Masz w domu dużo układów scalonych i nawet nie wiesz co masz na stanie a co powinieneś kupić. Na przykład ja ostatnio przeglądałem szafe i znalazłem jakieś IC nawet nie wiem skąd się wzieły. Co z tym zrobić? Rozwiązaniem jest ElectronDepot. Jest to aplikacja składająca się z servera oraz clienta.
# Server
- Zawiera baze danych zebranych przez ten czas układów scalonych.
- Układy scalone przechowywane dla konkretnego użytkownika.
- Udostępnia RestAPI umożliwiając pobranie zawartych danych z bd.
- Umożliwia ściąganie danych na temat zakupionych części na bierząco (np. poprzez skanowanie emaili z powiadomieniem o przesyłce. Może obsługiwać powiadomienia z takich sklepów jak Allegro, Botland, Kamami, MSalamon czy AliExpress)
- Umożliwia przechowywanie informacji na temat gdzie zastosowane zostały dane części (nazwa projektu i jakie części)

# Client
- Aplikacja desktopowa/webowa pozwalająca na interakcję z serverem.
- Filtrowanie/sortowanie/przeszukiwanie urządzeń które są dostępne
- Dodawnie nowych urządzeń oraz modyfikowanie wykorzystania istniejących.
- Tworzenie projektów i przypisywanie wykorzystania modułów.
- Konfiguracja serwisów które będą śledzone do otrzymywania automatycznego dodawnia do bazy danych.
- Logowanie na danego użytkownika.

---
# Architektura
## Server
- RestAPI napisane za pomocą ASP.NET Core.
- Skrypt do web-scrapowania w C#.
---
# Baza danych
```
+----------------+         +-----------------+         +-----------------+
|     Users      |         |   Components    |         |   Categories    |
+----------------+         +-----------------+         +-----------------+
| UserID (PK)    |<--------| ComponentID (PK)|         | CategoryID (PK) |
| Username       |         | UserID (FK)     |         | Name            |
| Email          |         | Name            |         | Description     |
| Password       |         | CategoryID (FK) |<--------|                 |
+----------------+         | Manufacturer    |         +-----------------+
                           | Quantity        |
                           | Location        |
                           +-----------------+
                                  |
                                  |
                                  v
+----------------+         +-----------------+        +------------------+
|    Projects    |<------->| ComponentProject|        |   Purchases      |
+----------------+         +-----------------+        +------------------+
| ProjectID (PK) |         | ProjectID (FK)  |        | PurchaseID (PK)  |
| UserID (FK)    |         | ComponentID (FK)|        | UserID (FK)      |
| Name           |         | QuantityUsed    |        | SupplierID (FK)  |
| Description    |         +-----------------+        | TotalPrice       |
+----------------+                                    | PurchaseDate     |
                                                      +------------------+
                                                              |
                                                              v
                                                      +------------------+
                                                      |  PurchaseItems   |
                                                      +------------------+
                                                      | PurchaseItemID   |
                                                      | PurchaseID (FK)  |
                                                      | ComponentID (FK) |
                                                      | Quantity         |
                                                      | PricePerUnit     |
                                                      +------------------+
                                                              |
                                                              v
                                                      +------------------+
                                                      |    Suppliers     |
                                                      +------------------+
                                                      | SupplierID (PK)  |
                                                      | Name             |
                                                      | Website          |
                                                      +------------------+

```
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

Jak powinna wyglądać architektura bazy danych dla takiego projektu?
## Client
- Desktopowa aplikacja napisana w C#/WPF.
#### Aplikacja