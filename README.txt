Probleem met NuGet:
Error "Project 'Default' is not found" bij Scaffold-DbContext.
Alle oplossingen gevonden online zeggen om verschillende programma's/extensies te verwijderen en opnieuw te installeren maar daar is niet genoeg tijd voor.
Ik heb de entities zelf handmatig toegevoegd nu als tijdelijke oplossing.
Hieronder wat ik bij scaffolding zou gebruikt hebben:
Scaffold-DbContext -Connection "Data Source=KEZZIES-LAPTOP\SQLEXPRESS;Initial Catalog=EventLite;Integrated Security=True" -Provider Microsoft.EntityFrameworkCore.SQLServer -OutputDir Entities -Tables *
