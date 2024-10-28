#define NOT_EXTENDED_DATA
using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.Models;

public static class TestingDataSeeder
{
    public static async Task SeedDataAsync(DatabaseContext context)
    {
        await context.ProjectComponents.ExecuteDeleteAsync();
        await context.PurchaseItems.ExecuteDeleteAsync();
        await context.OwnsComponent.ExecuteDeleteAsync();

        await context.Projects.ExecuteDeleteAsync();
        await context.Purchases.ExecuteDeleteAsync();
        await context.Components.ExecuteDeleteAsync();

        await context.Users.ExecuteDeleteAsync();
        await context.Suppliers.ExecuteDeleteAsync();
        await context.Categories.ExecuteDeleteAsync();

        await context.SaveChangesAsync();

        if (!context.Users.Any())
        {
            List<User> users = new List<User>
            {
                new User { Username = "jacek.jaworek", Password = "FindMeIfYouCan123", Email = "jacek.jaworek@gmail.com" },
                new User { Username = "agnieszka.nakowicz", Password = "mocSensora789", Email = "agnieszka.nakowicz@gmail.com" },
                new User { Username = "hanna.kozłowska", Password = "IoTAndBeyond456", Email = "hanna.kozłowska@gmail.com" },
                new User { Username = "piotr.wisniewski", Password = "powerSupplyGuru", Email = "piotr.wisniewski@gmail.com" },
                new User { Username = "jarosław.paduch", Password = "TylkoAVR420", Email = "jarosław.paduch@gmail.com" },
                new User { Username = "andrzej.kowalski", Password = "PiMasters2023", Email = "andrzej.kowalski@gmail.com" },
                new User { Username = "oleg.ontemijczuk", Password = "tylkoWindowsEmbedded", Email = "oleg.ontemijczuk@gmail.com" },
                new User { Username = "ewa.maj", Password = "SecureNetworking45", Email = "ewa.maj@gmail.com" },
                new User { Username = "grzegorz.baron", Password = "digitalSeamanProcessing", Email = "grzegorz.baron@gmail.com" },
                new User { Username = "joanna.pawlowska", Password = "SmartHomeLife55", Email = "joanna.pawlowska@gmail.com" }
            };

            context.Users.AddRange(users);
            await context.SaveChangesAsync();

            List<Category> categories = new List<Category>
            {
                new Category { Name = "Czujnik ciśnienia", Description = "Mierzy ciśnienie" },
                new Category { Name = "Czujnik czystości powietrza", Description = "Mierzy poziom czystości powietrza" },
                new Category { Name = "Czujnik gestów", Description = "Wykrywa gesty" },
                new Category { Name = "Czujnik krańcowe", Description = "Wykrywa osiągnięcie krańca ruchu" },
                new Category { Name = "Czujnik gazów", Description = "Mierzy stężenie gazów" },
                new Category { Name = "Czujnik magnetyczne", Description = "Wykrywa pole magnetyczne" },
                new Category { Name = "Czujnik odbiciowe", Description = "Wykrywa obiekty przez odbicie światła" },
                new Category { Name = "Czujnik odległości", Description = "Mierzy odległość" },
                new Category { Name = "Czujnik temperatury", Description = "Mierzy temperaturę" },
                new Category { Name = "Czujnik wilgotności", Description = "Mierzy wilgotność" },
                new Category { Name = "Enkodery", Description = "Mierzą pozycję kątową lub liniową" },
                new Category { Name = "Fotorezystory", Description = "Zmieniają opór w zależności od światła" },
                new Category { Name = "Fototranzystory", Description = "Wykrywają światło za pomocą tranzystora" },
                new Category { Name = "Odbiornik podczerwieni", Description = "Odbiera sygnały podczerwieni" },
                new Category { Name = "Akcelerometry", Description = "Mierzy przyspieszenie" },
                new Category { Name = "Czujnik hallotronowe", Description = "Wykrywa pole magnetyczne za pomocą efektu Halla" }
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            List<Supplier> suppliers = new List<Supplier>
            {
                new Supplier { Name = "Botland", Website = "https://botland.com.pl/" },
                new Supplier { Name = "MSalamon", Website = "https://msalamon.pl/" },
                new Supplier { Name = "DigiKey", Website = "https://www.digikey.pl/" },
                new Supplier { Name = "Mouser", Website = "https://eu.mouser.com/" },
                new Supplier { Name = "Aliexpress", Website = "https://pl.aliexpress.com//" },
                new Supplier { Name = "Kamami", Website = "https://kamami.pl/" }
            };
            context.Suppliers.AddRange(suppliers);
            await context.SaveChangesAsync();

            List<Component> components = new List<Component>
            {
                // Czujniki ciśnienia
                new Component { Name = "BMP180", Manufacturer = "Bosch", Description = "Czujnik ciśnienia barometrycznego", CategoryID = categories[0].CategoryID },
                new Component { Name = "MPX5700AP", Manufacturer = "NXP", Description = "Czujnik ciśnienia absolutnego", CategoryID = categories[0].CategoryID },
                new Component { Name = "MPX5010", Manufacturer = "NXP", Description = "Czujnik ciśnienia różnicowego o zakresie 0-10 kPa", CategoryID = categories[0].CategoryID },
                new Component { Name = "BMP280", Manufacturer = "Bosch", Description = "Czujnik ciśnienia atmosferycznego i wysokościomierz", CategoryID = categories[0].CategoryID },
#if !NOT_EXTENDED_DATA
                new Component { Name = "LPS22HB", Manufacturer = "STMicroelectronics", Description = "Czujnik ciśnienia barometrycznego o niskim zużyciu energii", CategoryID = categories[0].CategoryID },
                new Component { Name = "Honeywell MPRLS", Manufacturer = "Honeywell", Description = "Czujnik ciśnienia o wysokiej precyzji, kompaktowy", CategoryID = categories[0].CategoryID },
                new Component { Name = "MS5611", Manufacturer = "TE Connectivity", Description = "Cyfrowy czujnik ciśnienia barometrycznego o wysokiej precyzji", CategoryID = categories[0].CategoryID },
                new Component { Name = "AMS 5915", Manufacturer = "AMSYS", Description = "Czujnik ciśnienia absolutnego i różnicowego z wyjściem cyfrowym", CategoryID = categories[0].CategoryID },
                new Component { Name = "MPL3115A2", Manufacturer = "NXP", Description = "Czujnik ciśnienia atmosferycznego i wysokości z funkcją I2C", CategoryID = categories[0].CategoryID },
                new Component { Name = "SM5420", Manufacturer = "Senba Sensing", Description = "Czujnik ciśnienia różnicowego o dużej stabilności", CategoryID = categories[0].CategoryID },
                new Component { Name = "MSP300", Manufacturer = "TE Connectivity", Description = "Przemysłowy czujnik ciśnienia do zastosowań wymagających wysokiej dokładności", CategoryID = categories[0].CategoryID },
                new Component { Name = "HP03S", Manufacturer = "HopeRF", Description = "Czujnik ciśnienia barometrycznego o dużej czułości", CategoryID = categories[0].CategoryID },
                new Component { Name = "24PC Series", Manufacturer = "Honeywell", Description = "Miniaturowy, analogowy czujnik ciśnienia", CategoryID = categories[0].CategoryID },
                new Component { Name = "PX3 Series", Manufacturer = "Honeywell", Description = "Przemysłowy czujnik ciśnienia, wodoodporny", CategoryID = categories[0].CategoryID },
                new Component { Name = "DLVR Series", Manufacturer = "All Sensors", Description = "Czujnik ciśnienia niskiego zakresu o wysokiej precyzji", CategoryID = categories[0].CategoryID },
                new Component { Name = "SSC Series", Manufacturer = "Honeywell", Description = "Cyfrowy czujnik ciśnienia o szerokim zakresie i dużej dokładności", CategoryID = categories[0].CategoryID },
                new Component { Name = "MPR Series", Manufacturer = "Honeywell", Description = "Mały czujnik ciśnienia z kompensacją temperatury", CategoryID = categories[0].CategoryID },
                new Component { Name = "SPT025D", Manufacturer = "SENSYM", Description = "Miniaturowy czujnik ciśnienia różnicowego", CategoryID = categories[0].CategoryID },
                new Component { Name = "MPX5700DP", Manufacturer = "NXP", Description = "Czujnik ciśnienia różnicowego do 700 kPa", CategoryID = categories[0].CategoryID },
                new Component { Name = "MPXV7007", Manufacturer = "NXP", Description = "Niskozakresowy, różnicowy czujnik ciśnienia", CategoryID = categories[0].CategoryID },
                new Component { Name = "DPS310", Manufacturer = "Infineon", Description = "Precyzyjny czujnik ciśnienia atmosferycznego z interfejsem I2C/SPI", CategoryID = categories[0].CategoryID },
#endif
                new Component { Name = "APC301", Manufacturer = "Amphenol", Description = "Analogowy, przemysłowy czujnik ciśnienia", CategoryID = categories[0].CategoryID },

                // Czujniki czystości powietrza
                new Component { Name = "MQ-135", Manufacturer = "Winsen", Description = "Czujnik jakości powietrza", CategoryID = categories[1].CategoryID },
                new Component { Name = "CCS811", Manufacturer = "AMS", Description = "Czujnik gazów organicznych i CO2", CategoryID = categories[1].CategoryID },
                new Component { Name = "MQ-7", Manufacturer = "Winsen", Description = "Czujnik gazu do detekcji CO", CategoryID = categories[1].CategoryID },
#if !NOT_EXTENDED_DATA
                new Component { Name = "MH-Z19", Manufacturer = "Winsen", Description = "Czujnik CO2 z interfejsem UART", CategoryID = categories[1].CategoryID },
                new Component { Name = "BME680", Manufacturer = "Bosch", Description = "Czujnik jakości powietrza, temperatury, wilgotności i ciśnienia", CategoryID = categories[1].CategoryID },
                new Component { Name = "SDS011", Manufacturer = "Nova Fitness", Description = "Czujnik pyłów PM2.5 i PM10", CategoryID = categories[1].CategoryID },
                new Component { Name = "PMS5003", Manufacturer = "Plantower", Description = "Czujnik jakości powietrza do pomiaru PM2.5, PM10 oraz PM1.0", CategoryID = categories[1].CategoryID },
                new Component { Name = "MiCS-5524", Manufacturer = "MiCS", Description = "Czujnik gazów do detekcji CO, CH4, LPG, NH3", CategoryID = categories[1].CategoryID },
                new Component { Name = "GROVE - Gas Sensor V2", Manufacturer = "Seeed Studio", Description = "Czujnik gazu do detekcji różnych gazów, w tym CO2", CategoryID = categories[1].CategoryID },
#endif
                new Component { Name = "AQS-1", Manufacturer = "Air Quality Sensor", Description = "Czujnik jakości powietrza do pomiaru zanieczyszczeń i CO2", CategoryID = categories[1].CategoryID },

                // Czujniki gestów
                new Component { Name = "APDS-9960", Manufacturer = "Broadcom", Description = "Czujnik gestów, światła i koloru", CategoryID = categories[2].CategoryID },
                new Component { Name = "AS3935", Manufacturer = "ams AG", Description = "Czujnik gestów oraz detekcji burzy", CategoryID = categories[2].CategoryID },
                new Component { Name = "MTGesture", Manufacturer = "Microchip", Description = "Czujnik gestów 3D z funkcją zdalnego sterowania", CategoryID = categories[2].CategoryID },
#if !NOT_EXTENDED_DATA
                new Component { Name = "VCNL4010", Manufacturer = "Vishay", Description = "Czujnik gestów, światła i odległości", CategoryID = categories[2].CategoryID },
                new Component { Name = "TMD26711", Manufacturer = "TAOS", Description = "Czujnik gestów, światła oraz koloru z możliwością zdalnego sterowania", CategoryID = categories[2].CategoryID },
                new Component { Name = "PCA9555", Manufacturer = "NXP", Description = "Rozszerzenie GPIO z funkcją detekcji gestów", CategoryID = categories[2].CategoryID },
                new Component { Name = "APDS-9120", Manufacturer = "Broadcom", Description = "Czujnik światła i gestów z funkcją detekcji odległości", CategoryID = categories[2].CategoryID },
#endif
                new Component { Name = "ADPD188GG", Manufacturer = "Analog Devices", Description = "Czujnik optyczny do detekcji gestów i monitorowania zdrowia", CategoryID = categories[2].CategoryID },

                // Czujniki krańcowe
                new Component { Name = "Limit Switch KW12-3", Manufacturer = "Omron", Description = "Mechaniczny czujnik krańcowy", CategoryID = categories[3].CategoryID },
                new Component { Name = "ME-8108", Manufacturer = "Heschen", Description = "Przemysłowy czujnik krańcowy z dźwignią rolkową", CategoryID = categories[3].CategoryID },
                new Component { Name = "Omron D4MC", Manufacturer = "Omron", Description = "Mikroprzełącznik krańcowy z wysoką trwałością", CategoryID = categories[3].CategoryID },
                new Component { Name = "V-156-1C25", Manufacturer = "Honeywell", Description = "Przełącznik krańcowy z dźwignią rolkową", CategoryID = categories[3].CategoryID },
#if !NOT_EXTENDED_DATA
                new Component { Name = "TZ-8108", Manufacturer = "Honeywell", Description = "Kompaktowy wyłącznik krańcowy z ramieniem i rolką", CategoryID = categories[3].CategoryID },
                new Component { Name = "E2E-X5ME1", Manufacturer = "Omron", Description = "Indukcyjny czujnik krańcowy o zasięgu 5 mm", CategoryID = categories[3].CategoryID },
                new Component { Name = "LXW5-11G1", Manufacturer = "CHNT", Description = "Mechaniczny przełącznik krańcowy z dźwignią", CategoryID = categories[3].CategoryID },
                new Component { Name = "Microswitch KW10", Manufacturer = "Saia-Burgess", Description = "Mikroprzełącznik krańcowy o dużej czułości", CategoryID = categories[3].CategoryID },
                new Component { Name = "SPDT Limit Switch", Manufacturer = "Digi-Key", Description = "Miniaturowy czujnik krańcowy z trzpieniem", CategoryID = categories[3].CategoryID },
                new Component { Name = "Roller Lever Microswitch 1NO1NC", Manufacturer = "Panasonic", Description = "Przełącznik krańcowy z rolką, z jednym stykiem NO i NC", CategoryID = categories[3].CategoryID },
                new Component { Name = "XCK-J Limit Switch", Manufacturer = "Schneider Electric", Description = "Wytrzymały przełącznik krańcowy do zastosowań przemysłowych", CategoryID = categories[3].CategoryID },
#endif
                new Component { Name = "MLC-S-130L", Manufacturer = "Honeywell", Description = "Kompaktowy krańcowy czujnik z krótkim ramieniem", CategoryID = categories[3].CategoryID },

                // Czujniki gazów
                new Component { Name = "MQ-2", Manufacturer = "Hanwei", Description = "Czujnik gazów palnych i dymu", CategoryID = categories[4].CategoryID },
                new Component { Name = "MH-Z19B", Manufacturer = "Winsen", Description = "Czujnik dwutlenku węgla (CO2)", CategoryID = categories[4].CategoryID },
                new Component { Name = "MQ-2", Manufacturer = "Hanwei Electronics", Description = "Czujnik gazów palnych i dymu, wykrywa LPG, metan, wodór", CategoryID = categories[4].CategoryID },
                new Component { Name = "MQ-3", Manufacturer = "Hanwei Electronics", Description = "Czujnik alkoholu do wykrywania oparów alkoholu", CategoryID = categories[4].CategoryID },
#if !NOT_EXTENDED_DATA
                new Component { Name = "MQ-7", Manufacturer = "Hanwei Electronics", Description = "Czujnik tlenku węgla (CO)", CategoryID = categories[4].CategoryID },
                new Component { Name = "MQ-135", Manufacturer = "Hanwei Electronics", Description = "Czujnik jakości powietrza, wykrywa amoniak, benzen, alkohol", CategoryID = categories[4].CategoryID },
                new Component { Name = "Figaro TGS2611", Manufacturer = "Figaro", Description = "Czujnik gazu ziemnego (metanu) o wysokiej czułości", CategoryID = categories[4].CategoryID },
                new Component { Name = "Figaro TGS2600", Manufacturer = "Figaro", Description = "Czujnik jakości powietrza, wykrywa zanieczyszczenia powietrza", CategoryID = categories[4].CategoryID },
                new Component { Name = "MiCS-5524", Manufacturer = "SGX Sensortech", Description = "Czujnik CO i CH4, kompaktowy do aplikacji mobilnych", CategoryID = categories[4].CategoryID },
                new Component { Name = "MiCS-6814", Manufacturer = "SGX Sensortech", Description = "Czujnik wielogazowy, wykrywa CO, NO2, NH3, CH4, C3H8, C4H10, H2, C2H5OH", CategoryID = categories[4].CategoryID },
                new Component { Name = "CCS811", Manufacturer = "AMS", Description = "Cyfrowy czujnik gazów lotnych (TVOC) i CO2", CategoryID = categories[4].CategoryID },
                new Component { Name = "MH-Z19", Manufacturer = "Winsen", Description = "Niezależny czujnik CO2 z wbudowanym modułem UART", CategoryID = categories[4].CategoryID },
                new Component { Name = "GM-102B", Manufacturer = "Winsen", Description = "Czujnik ozonu (O3)", CategoryID = categories[4].CategoryID },
                new Component { Name = "MG-811", Manufacturer = "Sandbox Electronics", Description = "Czujnik CO2 o wysokiej czułości, kompatybilny z Arduino", CategoryID = categories[4].CategoryID },
                new Component { Name = "ZE07-CO", Manufacturer = "Winsen", Description = "Elektrochemiczny czujnik tlenku węgla (CO)", CategoryID = categories[4].CategoryID },
                new Component { Name = "MiCS-2714", Manufacturer = "SGX Sensortech", Description = "Czujnik dwutlenku azotu (NO2)", CategoryID = categories[4].CategoryID },
                new Component { Name = "MQ-9", Manufacturer = "Hanwei Electronics", Description = "Czujnik CO i gazów palnych, idealny do wykrywania gazów LPG, CO i CH4", CategoryID = categories[4].CategoryID },
                new Component { Name = "NDIR CO2 Sensor MH-Z14A", Manufacturer = "Winsen", Description = "Czujnik CO2 na podczerwień (NDIR) o wysokiej precyzji", CategoryID = categories[4].CategoryID },
                new Component { Name = "SEN0321", Manufacturer = "DFRobot", Description = "Przenośny czujnik amoniaku (NH3)", CategoryID = categories[4].CategoryID },
                new Component { Name = "SPEC Sensors 3SP_CO_1000", Manufacturer = "SPEC Sensors", Description = "Elektrochemiczny czujnik tlenku węgla (CO)", CategoryID = categories[4].CategoryID },
                new Component { Name = "SGP30", Manufacturer = "Sensirion", Description = "Czujnik wielogazowy, wykrywa CO2 i lotne związki organiczne (TVOC)", CategoryID = categories[4].CategoryID },
#endif
                new Component { Name = "ZP07-O3", Manufacturer = "Winsen", Description = "Czujnik ozonu (O3) do pomiaru jakości powietrza", CategoryID = categories[4].CategoryID },

                // Czujniki magnetyczne
                new Component { Name = "A3144", Manufacturer = "Allegro", Description = "Czujnik Halla do wykrywania pola magnetycznego", CategoryID = categories[5].CategoryID },
                new Component { Name = "TLE493D", Manufacturer = "Infineon", Description = "Czujnik Halla z trzema osiami do pomiaru pola magnetycznego", CategoryID = categories[5].CategoryID },
                new Component { Name = "LIS3MDL", Manufacturer = "STMicroelectronics", Description = "Czujnik magnetyczny 3-osiowy z możliwością pomiaru pól magnetycznych", CategoryID = categories[5].CategoryID },
                new Component { Name = "HMC5883L", Manufacturer = "Honeywell", Description = "Czujnik kompasu 3-osiowego, który wykorzystuje technologię magnetyczną", CategoryID = categories[5].CategoryID },
                new Component { Name = "MMT-3D", Manufacturer = "Microchip", Description = "Czujnik Halla do pomiaru pola magnetycznego w trzech wymiarach", CategoryID = categories[5].CategoryID },

                // Czujniki odbiciowe
                new Component { Name = "TCRT5000", Manufacturer = "Vishay", Description = "Odbiciowy czujnik optyczny", CategoryID = categories[6].CategoryID },
                new Component { Name = "QRD1114", Manufacturer = "Fairchild", Description = "Odbiciowy czujnik optyczny do detekcji obiektów", CategoryID = categories[6].CategoryID },
                new Component { Name = "TSOP4838", Manufacturer = "Vishay", Description = "Odbiciowy czujnik optyczny, odbiornik IR", CategoryID = categories[6].CategoryID },
                new Component { Name = "GP2Y0A21YK0F", Manufacturer = "Sharp", Description = "Odbiciowy czujnik odległości z analogowym wyjściem", CategoryID = categories[6].CategoryID },
                new Component { Name = "TCS3200", Manufacturer = "Texas Instruments", Description = "Odbiciowy czujnik koloru z detekcją światła", CategoryID = categories[6].CategoryID },

                // Czujniki odległości
                new Component { Name = "HC-SR04", Manufacturer = "Elecfreaks", Description = "Ultradźwiękowy czujnik odległości", CategoryID = categories[7].CategoryID },
                new Component { Name = "VL53L0X", Manufacturer = "STMicroelectronics", Description = "Czujnik odległości oparty na pomiarze czasu przelotu", CategoryID = categories[7].CategoryID },
                new Component { Name = "SRF05", Manufacturer = "SRF", Description = "Ultradźwiękowy czujnik odległości z pomiarem do 4 metrów", CategoryID = categories[7].CategoryID },
                new Component { Name = "GP2Y0A02YK0F", Manufacturer = "Sharp", Description = "Czujnik odległości z analogowym wyjściem do 2 metrów", CategoryID = categories[7].CategoryID },
                new Component { Name = "LIDAR-Lite v3", Manufacturer = "Garmin", Description = "Czujnik LIDAR do dokładnego pomiaru odległości", CategoryID = categories[7].CategoryID },
                new Component { Name = "ToF Rangefinder", Manufacturer = "Benewake", Description = "Czujnik odległości Time-of-Flight, wysoka dokładność i szybki pomiar", CategoryID = categories[7].CategoryID },

                // Czujniki temperatury
                new Component { Name = "DS18B20", Manufacturer = "Maxim Integrated", Description = "Cyfrowy czujnik temperatury", CategoryID = categories[8].CategoryID },
                new Component { Name = "LM35", Manufacturer = "Texas Instruments", Description = "Analogowy czujnik temperatury", CategoryID = categories[8].CategoryID },
                new Component { Name = "BME280", Manufacturer = "Bosch", Description = "Czujnik temperatury, wilgotności i ciśnienia atmosferycznego", CategoryID = categories[8].CategoryID },
                new Component { Name = "TMP36", Manufacturer = "Analog Devices", Description = "Analogowy czujnik temperatury o wysokiej dokładności", CategoryID = categories[8].CategoryID },
#if !NOT_EXTENDED_DATA
                new Component { Name = "NTC Thermistor 10k", Manufacturer = "Semitec", Description = "Termistor NTC do pomiaru temperatury, rezystancja 10kΩ", CategoryID = categories[8].CategoryID },
                new Component { Name = "PT100", Manufacturer = "Omega", Description = "Platinumowy rezystancyjny czujnik temperatury (RTD)", CategoryID = categories[8].CategoryID },
                new Component { Name = "MCP9808", Manufacturer = "Microchip", Description = "Cyfrowy czujnik temperatury o wysokiej dokładności i małym zużyciu energii", CategoryID = categories[8].CategoryID },
                new Component { Name = "SHT31", Manufacturer = "Sensirion", Description = "Cyfrowy czujnik temperatury i wilgotności o dużej precyzji", CategoryID = categories[8].CategoryID },
                new Component { Name = "LM75A", Manufacturer = "NXP", Description = "Cyfrowy czujnik temperatury I2C o zakresie -55 do 125°C", CategoryID = categories[8].CategoryID },
                new Component { Name = "K-Type Thermocouple", Manufacturer = "Omega", Description = "Termopara typu K do pomiarów w szerokim zakresie temperatur", CategoryID = categories[8].CategoryID },
                new Component { Name = "ADT7410", Manufacturer = "Analog Devices", Description = "Cyfrowy czujnik temperatury o wysokiej rozdzielczości (16-bit)", CategoryID = categories[8].CategoryID },
                new Component { Name = "Si7051", Manufacturer = "Silicon Labs", Description = "Precyzyjny czujnik temperatury o małym poborze mocy", CategoryID = categories[8].CategoryID },
                new Component { Name = "MLX90614", Manufacturer = "Melexis", Description = "Bezdotykowy czujnik temperatury na podczerwień", CategoryID = categories[8].CategoryID },
                new Component { Name = "HTU21D", Manufacturer = "TE Connectivity", Description = "Cyfrowy czujnik temperatury i wilgotności", CategoryID = categories[8].CategoryID },
                new Component { Name = "MAX30205", Manufacturer = "Maxim Integrated", Description = "Medyczny czujnik temperatury, precyzyjny do ±0.1°C", CategoryID = categories[8].CategoryID },
                new Component { Name = "TC74", Manufacturer = "Microchip", Description = "Cyfrowy czujnik temperatury z interfejsem I2C", CategoryID = categories[8].CategoryID },
                new Component { Name = "SHTC3", Manufacturer = "Sensirion", Description = "Ultraniskomocowy cyfrowy czujnik temperatury i wilgotności", CategoryID = categories[8].CategoryID },
                new Component { Name = "TMP117", Manufacturer = "Texas Instruments", Description = "Precyzyjny cyfrowy czujnik temperatury o zakresie -55 do 150°C", CategoryID = categories[8].CategoryID },
                new Component { Name = "TSYS01", Manufacturer = "TE Connectivity", Description = "Cyfrowy czujnik temperatury o dużej dokładności", CategoryID = categories[8].CategoryID },
                new Component { Name = "LMT87", Manufacturer = "Texas Instruments", Description = "Analogowy czujnik temperatury w małym opakowaniu TO-92", CategoryID = categories[8].CategoryID },
#endif
                new Component { Name = "HDC1080", Manufacturer = "Texas Instruments", Description = "Cyfrowy czujnik temperatury i wilgotności, niskopoborowy", CategoryID = categories[8].CategoryID },

                // Czujniki wilgotności
                new Component { Name = "DHT22", Manufacturer = "AOSONG", Description = "Cyfrowy czujnik wilgotności i temperatury", CategoryID = categories[9].CategoryID },
                new Component { Name = "AM2301", Manufacturer = "AOSONG", Description = "Cyfrowy czujnik wilgotności i temperatury", CategoryID = categories[9].CategoryID },
                new Component { Name = "SHT31", Manufacturer = "Sensirion", Description = "Cyfrowy czujnik wilgotności i temperatury o wysokiej precyzji", CategoryID = categories[9].CategoryID },
#if !NOT_EXTENDED_DATA
                new Component { Name = "HTU21D", Manufacturer = "TE Connectivity", Description = "Czujnik wilgotności i temperatury z interfejsem I2C", CategoryID = categories[9].CategoryID },
                new Component { Name = "HDC1080", Manufacturer = "Texas Instruments", Description = "Niskomocowy czujnik wilgotności i temperatury", CategoryID = categories[9].CategoryID },
                new Component { Name = "Si7021", Manufacturer = "Silicon Labs", Description = "Cyfrowy czujnik wilgotności i temperatury o niskim poborze mocy", CategoryID = categories[9].CategoryID },
                new Component { Name = "BME280", Manufacturer = "Bosch", Description = "Czujnik wilgotności, temperatury i ciśnienia, wielofunkcyjny", CategoryID = categories[9].CategoryID },
                new Component { Name = "RHT03", Manufacturer = "MaxDetect", Description = "Cyfrowy czujnik wilgotności i temperatury, kompatybilny z DHT22", CategoryID = categories[9].CategoryID },
#endif
                new Component { Name = "SHTC3", Manufacturer = "Sensirion", Description = "Miniaturowy cyfrowy czujnik wilgotności i temperatury", CategoryID = categories[9].CategoryID },

                // Enkodery
                new Component { Name = "KY-040", Manufacturer = "Keyes", Description = "Obrotowy enkoder do wykrywania położenia kątowego", CategoryID = categories[10].CategoryID },
                new Component { Name = "EC11", Manufacturer = "Bourns", Description = "Obrotowy enkoder z przyciskiem, idealny do regulacji i nawigacji", CategoryID = categories[10].CategoryID },
                new Component { Name = "KY-040", Manufacturer = "Keyes", Description = "Obrotowy enkoder z wyjściem analogowym, do pomiaru kąta obrotu", CategoryID = categories[10].CategoryID },
                new Component { Name = "Bourns PEC11R", Manufacturer = "Bourns", Description = "Ciche, rotacyjne enkodery z wieloma wyjściami, idealne do projektów audio", CategoryID = categories[10].CategoryID },
                new Component { Name = "AMT102", Manufacturer = "CUI Devices", Description = "Inkrementalny enkoder obrotowy z wyjściem cyfrowym, wysokiej precyzji", CategoryID = categories[10].CategoryID },

                // Fotorezystory
                new Component { Name = "GL5528", Manufacturer = "GLT", Description = "Fotorezystor reagujący na poziom światła", CategoryID = categories[11].CategoryID },
                new Component { Name = "GL5537", Manufacturer = "GLT", Description = "Fotorezystor reagujący na światło, stosowany w automatyce", CategoryID = categories[11].CategoryID },
                new Component { Name = "LDR", Manufacturer = "General", Description = "Czujnik światła, fotorezystor o dużej czułości, używany w aplikacjach DIY", CategoryID = categories[11].CategoryID },
                new Component { Name = "TSL2591", Manufacturer = "Adafruit", Description = "Cyfrowy czujnik światła o wysokiej czułości z interfejsem I2C", CategoryID = categories[11].CategoryID },
                new Component { Name = "VEML6075", Manufacturer = "Vishay", Description = "Fotorezystor UV do pomiaru poziomu promieniowania ultrafioletowego", CategoryID = categories[11].CategoryID },

                // Fototranzystory
                new Component { Name = "PT333-3C", Manufacturer = "Everlight", Description = "Fototranzystor czuły na światło widzialne", CategoryID = categories[12].CategoryID },
                new Component { Name = "LPT-80", Manufacturer = "Lite-On", Description = "Fototranzystor czuły na światło widzialne, idealny do detekcji obiektów", CategoryID = categories[12].CategoryID },
                new Component { Name = "HPT-20", Manufacturer = "Everlight", Description = "Fototranzystor o wysokiej czułości, przeznaczony do zastosowań optoelektronicznych", CategoryID = categories[12].CategoryID },
                new Component { Name = "PT203-3C", Manufacturer = "Everlight", Description = "Fototranzystor do zastosowań ogólnych, czuły na światło widzialne", CategoryID = categories[12].CategoryID },
                new Component { Name = "LPT-80", Manufacturer = "Lite-On", Description = "Fototranzystor o dużej wydajności i niskim napięciu, stosowany w aplikacjach automatyki", CategoryID = categories[12].CategoryID },

                // Odbiorniki podczerwieni
                new Component { Name = "TSOP38238", Manufacturer = "Vishay", Description = "Odbiornik podczerwieni do dekodowania sygnałów IR", CategoryID = categories[13].CategoryID },
                new Component { Name = "TSOP38240", Manufacturer = "Vishay", Description = "Odbiornik podczerwieni do dekodowania sygnałów IR w zakresie 40 kHz", CategoryID = categories[13].CategoryID },
                new Component { Name = "VS1838B", Manufacturer = "Vishay", Description = "Odbiornik podczerwieni o dużej czułości i niskim poborze mocy", CategoryID = categories[13].CategoryID },
                new Component { Name = "GP1UX511QS", Manufacturer = "Sharp", Description = "Odbiornik podczerwieni z dużym zasięgiem i wąskim kątem detekcji", CategoryID = categories[13].CategoryID },
                new Component { Name = "RPR-220", Manufacturer = "Rohm", Description = "Odbiornik podczerwieni, przeznaczony do różnych zastosowań IR", CategoryID = categories[13].CategoryID },

                // Akcelerometry
                new Component { Name = "ADXL345", Manufacturer = "Analog Devices", Description = "Trójosiowy akcelerometr", CategoryID = categories[14].CategoryID },
                new Component { Name = "LIS3DH", Manufacturer = "STMicroelectronics", Description = "Trójosiowy akcelerometr z cyfrowym wyjściem I2C/SPI", CategoryID = categories[14].CategoryID },
                new Component { Name = "BMA220", Manufacturer = "Bosch", Description = "Miniaturowy trójosiowy akcelerometr z niskim poborem mocy", CategoryID = categories[14].CategoryID },
                new Component { Name = "MPU6050", Manufacturer = "InvenSense", Description = "Akcelerometr 3-osiowy z żyroskopem 3-osiowym w jednym chipie", CategoryID = categories[14].CategoryID },
                new Component { Name = "ADXL362", Manufacturer = "Analog Devices", Description = "Trójosiowy akcelerometr z ultra-niskim poborem mocy i funkcją detekcji ruchu", CategoryID = categories[14].CategoryID },

                // Czujniki hallotronowe
                new Component { Name = "DRV5053", Manufacturer = "Texas Instruments", Description = "Czujnik Halla, liniowy pomiar pola magnetycznego", CategoryID = categories[15].CategoryID },
                new Component { Name = "A3141", Manufacturer = "Allegro", Description = "Czujnik Halla do pomiaru pola magnetycznego z analogowym wyjściem", CategoryID = categories[15].CategoryID },
                new Component { Name = "HMC5883L", Manufacturer = "Honeywell", Description = "Czujnik 3-osiowy Halla do pomiaru pola magnetycznego", CategoryID = categories[15].CategoryID },
                new Component { Name = "TLE493D-W2B6", Manufacturer = "Infineon", Description = "Czujnik Halla o niskim poborze mocy z możliwością pomiaru pól magnetycznych", CategoryID = categories[15].CategoryID },
                new Component { Name = "DRV5055", Manufacturer = "Texas Instruments", Description = "Czujnik Halla, liniowy pomiar pola magnetycznego z wyjściem analogowym", CategoryID = categories[15].CategoryID }
            };
            context.Components.AddRange(components);
            await context.SaveChangesAsync();

            var purchases = new List<Purchase>
            {
                new Purchase { UserID = users[0].UserID, SupplierID = suppliers[0].SupplierID, PurchasedDate = DateTime.Now, TotalPrice = 100.50 },
                new Purchase { UserID = users[1].UserID, SupplierID = suppliers[1].SupplierID, PurchasedDate = DateTime.Now, TotalPrice = 150.75 }
            };
            context.Purchases.AddRange(purchases);
            await context.SaveChangesAsync();

            var purchaseItems = new List<PurchaseItem>
            {
                new PurchaseItem { PurchaseID = purchases[0].PurchaseID, ComponentID = components[0].ComponentID, Quantity = 10, PricePerUnit = 5.05 },
                new PurchaseItem { PurchaseID = purchases[1].PurchaseID, ComponentID = components[1].ComponentID, Quantity = 5, PricePerUnit = 10.15 }
            };
            context.PurchaseItems.AddRange(purchaseItems);
            await context.SaveChangesAsync();

            List<Project> projects = new List<Project>
            {
                new Project { UserID = users[0].UserID, Name = "Smart Home System", Description = "System automatyzacji domu", CreatedAt = DateTime.Now },
                new Project { UserID = users[1].UserID, Name = "Weather Station", Description = "Monitorowanie pogody", CreatedAt = DateTime.Now },
                new Project { UserID = users[2].UserID, Name = "Automated Irrigation System", Description = "System do automatycznego nawadniania ogrodu", CreatedAt = DateTime.Now },
                new Project { UserID = users[3].UserID, Name = "Home Security System", Description = "System monitorowania bezpieczeństwa domu", CreatedAt = DateTime.Now },
                new Project { UserID = users[0].UserID, Name = "Fitness Tracker", Description = "Aplikacja do monitorowania aktywności fizycznej", CreatedAt = DateTime.Now },
                new Project { UserID = users[1].UserID, Name = "Air Quality Monitor", Description = "System monitorowania jakości powietrza", CreatedAt = DateTime.Now },
                new Project { UserID = users[2].UserID, Name = "Industrial Automation", Description = "Automatyzacja procesów przemysłowych", CreatedAt = DateTime.Now },
                new Project { UserID = users[3].UserID, Name = "Plant Monitoring System", Description = "System monitorowania wilgotności gleby i zdrowia roślin", CreatedAt = DateTime.Now },
                new Project { UserID = users[4].UserID, Name = "Smart Lighting System", Description = "Automatyczne oświetlenie zależne od warunków otoczenia", CreatedAt = DateTime.Now },
                new Project { UserID = users[5].UserID, Name = "Remote Health Monitoring", Description = "Zdalny system monitorowania parametrów zdrowotnych", CreatedAt = DateTime.Now },
                new Project { UserID = users[6].UserID, Name = "Energy Management System", Description = "Monitorowanie zużycia energii elektrycznej w domu", CreatedAt = DateTime.Now },
                new Project { UserID = users[7].UserID, Name = "Robot Navigation", Description = "System nawigacji dla robota autonomicznego", CreatedAt = DateTime.Now },
                new Project { UserID = users[8].UserID, Name = "Voice Controlled Assistant", Description = "Asystent głosowy do sterowania urządzeniami w domu", CreatedAt = DateTime.Now },
                new Project { UserID = users[9].UserID, Name = "Smart Thermostat", Description = "Inteligentny system zarządzania temperaturą w domu", CreatedAt = DateTime.Now }
            };
            context.Projects.AddRange(projects);
            await context.SaveChangesAsync();

            var projectComponents = new List<ProjectComponent>
            {
                new ProjectComponent { ProjectID = projects[0].ProjectID, ComponentID = components[0].ComponentID, Quantity = 2 },
                new ProjectComponent { ProjectID = projects[1].ProjectID, ComponentID = components[1].ComponentID, Quantity = 1 }
            };
            context.ProjectComponents.AddRange(projectComponents);
            await context.SaveChangesAsync();

            var ownsComponents = new List<OwnsComponent>
            {
                new OwnsComponent { UserID = users[0].UserID, ComponentID = components[0].ComponentID, Quantity = 3 },
                new OwnsComponent { UserID = users[1].UserID, ComponentID = components[1].ComponentID, Quantity = 1 }
            };
            context.OwnsComponent.AddRange(ownsComponents);
            await context.SaveChangesAsync();
        }
    }
}
