SystemIntegration – IT / OT / Integration

Detta repo innehåller tre separata konsolapplikationer som tillsammans visar ett enkelt exempel på systemintegration mellan ett IT-system, ett integrationslager och ett OT-system.

ITSystem

Skapar en databas OrderDb i SQL Server.

Innehåller en tabell Orders med kolumner för Id, ProductName och Quantity.

Seedar databasen med tre testordrar.

Listar alla ordrar i konsolen när programmet körs.

IntegrationSystem

Läser alla ordrar från databasen.

Använder EasyModbus för att skicka varje orders Id och Quantity till OTSystem via Modbus TCP.

Skriver i konsolen vilka ordrar som skickats.

OTSystem

Startar en Modbus-server som lyssnar på port 502.

Tar emot värden från IntegrationSystem.

Loggar ut mottagna OrderId och Quantity i konsolen.

Hur man kör

Starta ITSystem för att skapa databasen och se till att ordrar finns.

Starta OTSystem så att Modbus-servern lyssnar.

Starta IntegrationSystem för att läsa ordrar från databasen och skicka dem till OTSystem.

Kontrollera konsolen i OTSystem för att se mottagna OrderId och Quantity.

Teknik

C# (.NET)

Entity Framework Core

SQL Server

EasyModbus (Modbus TCP)
