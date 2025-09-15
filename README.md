Systemintegration – IT / OT / Integration
Syftet med detta projekt är att bygga en enkel men tydlig kedja för systemintegration mellan ett IT-system, ett integrationslager och ett OT-system.
I praktiken behöver många företag kunna koppla samman affärssystem (IT) med maskiner och utrustning i produktionen (OT). Här används C#, SQL Server och Modbus TCP för att demonstrera hur data kan flöda mellan systemen.

Detta projekt består av tre separata konsolapplikationer som tillsammans visar en enkel integration mellan ett IT-system, ett integrationslager och ett OT-system.

ITSystem

    -Skapar en SQL Server-databas OrderDb.

    -Innehåller tabellen Orders med kolumner för Id, ProductName och Quantity.

    -Databasen seedas med tre testordrar.

    -När programmet körs listas alla ordrar i konsolen.

IntegrationSystem

    Läser alla ordrar från databasen.

    Använder EasyModbus för att skicka varje orders Id och Quantity till OTSystem via Modbus TCP.

    Skriver ut i konsolen vilka ordrar som skickats.

OTSystem

    Startar en Modbus-server som lyssnar på port 502.

    Tar emot värden från IntegrationSystem.

    Skriver ut mottagna OrderId och Quantity i konsolen.

Så körs systemet

    Kör ITSystem för att skapa databasen och se till att det finns ordrar.

    Starta OTSystem så att Modbus-servern lyssnar.

    Kör IntegrationSystem för att läsa ordrar från databasen och skicka dem till OTSystem.

    Kontrollera OTSystem-konsolen för att se mottagna OrderId och Quantity.

Tekniker

-C# (.NET)

-Entity Framework Core

-SQL Server

-EasyModbus (Modbus TCP)
