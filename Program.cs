using astronova.Data;
using astronova.Entities;
using astronova.Entities.Enums;
using astronova.Repository;

var context = new AstronovaDbContext();
var astronautRepository = new AstronautsRepository(context);
var engineerRepository = new EngineersRepository(context);
var shipRepository = new ShipsRepository(context);
var missionRepository = new MissionsRepository(context);
var explorationLogRepository = new ExplorationLogsRepository(context);

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
    Console.WriteLine("║     SISTEMA DE GESTIÓN DE EXPLORACIÓN ESPACIAL - AstroNova  ║");
    Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
    Console.WriteLine("\n¿Qué deseas gestionar?\n");
    Console.WriteLine("1. Astronautas");
    Console.WriteLine("2. Ingenieros");
    Console.WriteLine("3. Naves");
    Console.WriteLine("4. Misiones");
    Console.WriteLine("5. Registros de Exploración");
    Console.WriteLine("0. Salir\n");
    Console.Write("Selecciona una opción: ");

    var mainChoice = Console.ReadLine();

    switch (mainChoice)
    {
        case "1":
            ManageAstronauts();
            break;
        case "2":
            ManageEngineers();
            break;
        case "3":
            ManageShips();
            break;
        case "4":
            ManageMissions();
            break;
        case "5":
            ManageExplorationLogs();
            break;
        case "0":
            running = false;
            Console.WriteLine("\n¡Hasta luego!");
            break;
        default:
            Console.WriteLine("\nOpción no válida. Presiona Enter para continuar...");
            Console.ReadLine();
            break;
    }
}

void ManageAstronauts()
{
    bool inMenu = true;
    while (inMenu)
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        Console.WriteLine("                    GESTIÓN DE ASTRONAUTAS");
        Console.WriteLine("═══════════════════════════════════════════════════════════\n");
        Console.WriteLine("1. Crear Astronauta");
        Console.WriteLine("2. Listar Astronautas");
        Console.WriteLine("3. Buscar Astronauta por ID");
        Console.WriteLine("4. Actualizar Astronauta");
        Console.WriteLine("5. Eliminar Astronauta");
        Console.WriteLine("0. Volver al Menú Principal\n");
        Console.Write("Selecciona una opción: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateAstronaut();
                break;
            case "2":
                ListAstronauts();
                break;
            case "3":
                GetAstronautById();
                break;
            case "4":
                UpdateAstronaut();
                break;
            case "5":
                DeleteAstronaut();
                break;
            case "0":
                inMenu = false;
                break;
            default:
                Console.WriteLine("\nOpción no válida. Presiona Enter para continuar...");
                Console.ReadLine();
                break;
        }
    }
}

void CreateAstronaut()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                    CREAR ASTRONAUTA");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Nombre: ");
    string? name = Console.ReadLine();

    Console.Write("Apellido: ");
    string? lastName = Console.ReadLine();

    Console.Write("Horas de Experiencia: ");
    int hoursExperience = int.Parse(Console.ReadLine() ?? "0");

    if (hoursExperience <= 0)
    {
        Console.WriteLine("\n❌ Error: Las horas de experiencia deben ser mayores a 0.");
        Console.ReadLine();
        return;
    }

    Console.WriteLine("\nRango:");
    Console.WriteLine("0. Rookie (Novato)");
    Console.WriteLine("1. Pilot (Piloto)");
    Console.WriteLine("2. Commander (Comandante)");
    Console.Write("Selecciona el rango: ");

    int rankChoice = int.Parse(Console.ReadLine() ?? "0");
    AstronautRank rank = (AstronautRank)rankChoice;

    var astronaut = new Astronauts
    {
        Name = name,
        LastName = lastName,
        HoursExperience = hoursExperience,
        Range = rank
    };

    astronautRepository.AddAstronaut(astronaut);
    Console.WriteLine("\n✅ Astronauta creado exitosamente. Presiona Enter para continuar...");
    Console.ReadLine();
}

void ListAstronauts()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                    LISTA DE ASTRONAUTAS");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    var astronauts = astronautRepository.GetAstronauts();

    if (!astronauts.Any())
    {
        Console.WriteLine("No hay astronautas registrados.");
    }
    else
    {
        foreach (var astro in astronauts)
        {
            Console.WriteLine($"\n┌─ ID: {astro.Id}");
            Console.WriteLine($"├─ Nombre: {astro.Name} {astro.LastName}");
            Console.WriteLine($"├─ Rango: {astro.Range}");
            Console.WriteLine($"└─ Horas de Experiencia: {astro.HoursExperience}");
        }
    }

    Console.WriteLine("\n\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void GetAstronautById()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("              BUSCAR ASTRONAUTA POR ID");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID del astronauta: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var astronaut = astronautRepository.GetAstronautById(id);

    if (astronaut == null)
    {
        Console.WriteLine($"\n❌ No se encontró astronauta con ID {id}.");
    }
    else
    {
        Console.WriteLine($"\n✅ Astronauta encontrado:");
        Console.WriteLine($"\n┌─ ID: {astronaut.Id}");
        Console.WriteLine($"├─ Nombre: {astronaut.Name} {astronaut.LastName}");
        Console.WriteLine($"├─ Rango: {astronaut.Range}");
        Console.WriteLine($"└─ Horas de Experiencia: {astronaut.HoursExperience}");
    }

    Console.WriteLine("\n\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void UpdateAstronaut()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                  ACTUALIZAR ASTRONAUTA");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID del astronauta a actualizar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var existing = astronautRepository.GetAstronautById(id);
    if (existing == null)
    {
        Console.WriteLine($"\n❌ No se encontró astronauta con ID {id}.");
        Console.ReadLine();
        return;
    }

    Console.Write("\nNuevo nombre (dejar en blanco para no cambiar): ");
    string? newName = Console.ReadLine();

    Console.Write("Nuevo apellido (dejar en blanco para no cambiar): ");
    string? newLastName = Console.ReadLine();

    Console.Write("Nuevas horas de experiencia (0 para no cambiar): ");
    int newHours = int.Parse(Console.ReadLine() ?? "0");

    if (newHours > 0 && newHours <= 0)
    {
        Console.WriteLine("\n❌ Error: Las horas de experiencia deben ser mayores a 0.");
        Console.ReadLine();
        return;
    }

    var updateAstronaut = new Astronauts
    {
        Name = string.IsNullOrWhiteSpace(newName) ? null : newName,
        LastName = string.IsNullOrWhiteSpace(newLastName) ? null : newLastName,
        HoursExperience = newHours > 0 ? newHours : null
    };

    astronautRepository.UpdateAstronaut(id, updateAstronaut);
    Console.WriteLine("\n✅ Astronauta actualizado exitosamente. Presiona Enter para continuar...");
    Console.ReadLine();
}

void DeleteAstronaut()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                  ELIMINAR ASTRONAUTA");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID del astronauta a eliminar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    bool result = astronautRepository.DeleteAstronaut(id);

    if (result)
    {
        Console.WriteLine($"\n✅ Astronauta con ID {id} eliminado exitosamente.");
    }
    else
    {
        Console.WriteLine($"\n❌ No se encontró astronauta con ID {id}.");
    }

    Console.WriteLine("\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void ManageEngineers()
{
    bool inMenu = true;
    while (inMenu)
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        Console.WriteLine("                    GESTIÓN DE INGENIEROS");
        Console.WriteLine("═══════════════════════════════════════════════════════════\n");
        Console.WriteLine("1. Crear Ingeniero");
        Console.WriteLine("2. Listar Ingenieros");
        Console.WriteLine("3. Buscar Ingeniero por ID");
        Console.WriteLine("4. Actualizar Ingeniero");
        Console.WriteLine("5. Eliminar Ingeniero");
        Console.WriteLine("0. Volver al Menú Principal\n");
        Console.Write("Selecciona una opción: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateEngineer();
                break;
            case "2":
                ListEngineers();
                break;
            case "3":
                GetEngineerById();
                break;
            case "4":
                UpdateEngineer();
                break;
            case "5":
                DeleteEngineer();
                break;
            case "0":
                inMenu = false;
                break;
            default:
                Console.WriteLine("\nOpción no válida. Presiona Enter para continuar...");
                Console.ReadLine();
                break;
        }
    }
}

void CreateEngineer()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                    CREAR INGENIERO");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Nombre: ");
    string? name = Console.ReadLine();

    Console.Write("Apellido: ");
    string? lastName = Console.ReadLine();

    Console.Write("Años de Experiencia: ");
    int yearExperience = int.Parse(Console.ReadLine() ?? "0");

    if (yearExperience <= 0)
    {
        Console.WriteLine("\n❌ Error: Los años de experiencia deben ser mayores a 0.");
        Console.ReadLine();
        return;
    }

    Console.WriteLine("\nEspecialidad:");
    Console.WriteLine("0. Propulsion (Propulsión)");
    Console.WriteLine("1. Systems (Sistemas)");
    Console.WriteLine("2. AI (Inteligencia Artificial)");
    Console.Write("Selecciona la especialidad: ");

    int specialtyChoice = int.Parse(Console.ReadLine() ?? "0");
    EngineerSpeciality specialty = (EngineerSpeciality)specialtyChoice;

    var engineer = new Engineers
    {
        Name = name,
        LastName = lastName,
        YearExperience = yearExperience,
        Specialty = specialty
    };

    engineerRepository.AddEngineer(engineer);
    Console.WriteLine("\n✅ Ingeniero creado exitosamente. Presiona Enter para continuar...");
    Console.ReadLine();
}

void ListEngineers()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                    LISTA DE INGENIEROS");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    var engineers = engineerRepository.GetEngineers();

    if (!engineers.Any())
    {
        Console.WriteLine("No hay ingenieros registrados.");
    }
    else
    {
        foreach (var eng in engineers)
        {
            Console.WriteLine($"\n┌─ ID: {eng.Id}");
            Console.WriteLine($"├─ Nombre: {eng.Name} {eng.LastName}");
            Console.WriteLine($"├─ Especialidad: {eng.Specialty}");
            Console.WriteLine($"└─ Años de Experiencia: {eng.YearExperience}");
        }
    }

    Console.WriteLine("\n\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void GetEngineerById()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("              BUSCAR INGENIERO POR ID");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID del ingeniero: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var engineer = engineerRepository.GetEnginnerById(id);

    if (engineer == null)
    {
        Console.WriteLine($"\n❌ No se encontró ingeniero con ID {id}.");
    }
    else
    {
        Console.WriteLine($"\n✅ Ingeniero encontrado:");
        Console.WriteLine($"\n┌─ ID: {engineer.Id}");
        Console.WriteLine($"├─ Nombre: {engineer.Name} {engineer.LastName}");
        Console.WriteLine($"├─ Especialidad: {engineer.Specialty}");
        Console.WriteLine($"└─ Años de Experiencia: {engineer.YearExperience}");
    }

    Console.WriteLine("\n\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void UpdateEngineer()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                  ACTUALIZAR INGENIERO");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID del ingeniero a actualizar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var existing = engineerRepository.GetEnginnerById(id);
    if (existing == null)
    {
        Console.WriteLine($"\n❌ No se encontró ingeniero con ID {id}.");
        Console.ReadLine();
        return;
    }

    Console.Write("\nNuevo nombre (dejar en blanco para no cambiar): ");
    string? newName = Console.ReadLine();

    Console.Write("Nuevo apellido (dejar en blanco para no cambiar): ");
    string? newLastName = Console.ReadLine();

    Console.Write("Nuevos años de experiencia (0 para no cambiar): ");
    int newYears = int.Parse(Console.ReadLine() ?? "0");

    if (newYears < 0)
    {
        Console.WriteLine("\n❌ Error: Los años de experiencia no pueden ser negativos.");
        Console.ReadLine();
        return;
    }

    var updateEngineer = new Engineers
    {
        Name = string.IsNullOrWhiteSpace(newName) ? null : newName,
        LastName = string.IsNullOrWhiteSpace(newLastName) ? null : newLastName,
        YearExperience = newYears > 0 ? newYears : null
    };

    engineerRepository.UpdateEngineer(id, updateEngineer);
    Console.WriteLine("\n✅ Ingeniero actualizado exitosamente. Presiona Enter para continuar...");
    Console.ReadLine();
}

void DeleteEngineer()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                  ELIMINAR INGENIERO");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID del ingeniero a eliminar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    bool result = engineerRepository.DeleteEngineer(id);

    if (result)
    {
        Console.WriteLine($"\n✅ Ingeniero con ID {id} eliminado exitosamente.");
    }
    else
    {
        Console.WriteLine($"\n❌ No se encontró ingeniero con ID {id}.");
    }

    Console.WriteLine("\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void ManageShips()
{
    bool inMenu = true;
    while (inMenu)
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        Console.WriteLine("                      GESTIÓN DE NAVES");
        Console.WriteLine("═══════════════════════════════════════════════════════════\n");
        Console.WriteLine("1. Crear Nave");
        Console.WriteLine("2. Listar Naves");
        Console.WriteLine("3. Buscar Nave por ID");
        Console.WriteLine("4. Actualizar Nave");
        Console.WriteLine("5. Eliminar Nave");
        Console.WriteLine("0. Volver al Menú Principal\n");
        Console.Write("Selecciona una opción: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateShip();
                break;
            case "2":
                ListShips();
                break;
            case "3":
                GetShipById();
                break;
            case "4":
                UpdateShip();
                break;
            case "5":
                DeleteShip();
                break;
            case "0":
                inMenu = false;
                break;
            default:
                Console.WriteLine("\nOpción no válida. Presiona Enter para continuar...");
                Console.ReadLine();
                break;
        }
    }
}

void CreateShip()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                      CREAR NAVE");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Nombre de la nave: ");
    string? name = Console.ReadLine();

    Console.Write("Modelo: ");
    string? model = Console.ReadLine();

    Console.Write("Capacidad de tripulación: ");
    int crewCapacity = int.Parse(Console.ReadLine() ?? "0");

    if (crewCapacity <= 0)
    {
        Console.WriteLine("\n❌ Error: La capacidad de nave debe ser mayor a 0.");
        Console.ReadLine();
        return;
    }

    Console.WriteLine("\nEstado:");
    Console.WriteLine("0. Operational (Operativa)");
    Console.WriteLine("1. UnderMaintenance (En Mantenimiento)");
    Console.WriteLine("2. Retired (Retirada)");
    Console.Write("Selecciona el estado: ");

    int statusChoice = int.Parse(Console.ReadLine() ?? "0");
    ShipStatus status = (ShipStatus)statusChoice;

    var ship = new Ships
    {
        Name = name,
        Model = model,
        CrewCapacity = crewCapacity,
        Status = status
    };

    shipRepository.AddShip(ship);
    Console.WriteLine("\n✅ Nave creada exitosamente. Presiona Enter para continuar...");
    Console.ReadLine();
}

void ListShips()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                      LISTA DE NAVES");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    var ships = shipRepository.GetShips();

    if (!ships.Any())
    {
        Console.WriteLine("No hay naves registradas.");
    }
    else
    {
        foreach (var ship in ships)
        {
            Console.WriteLine($"\n┌─ ID: {ship.Id}");
            Console.WriteLine($"├─ Nombre: {ship.Name}");
            Console.WriteLine($"├─ Modelo: {ship.Model}");
            Console.WriteLine($"├─ Capacidad de Tripulación: {ship.CrewCapacity}");
            Console.WriteLine($"└─ Estado: {ship.Status}");
        }
    }

    Console.WriteLine("\n\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void GetShipById()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("              BUSCAR NAVE POR ID");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID de la nave: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var ship = shipRepository.GetShipById(id);

    if (ship == null)
    {
        Console.WriteLine($"\n❌ No se encontró nave con ID {id}.");
    }
    else
    {
        Console.WriteLine($"\n✅ Nave encontrada:");
        Console.WriteLine($"\n┌─ ID: {ship.Id}");
        Console.WriteLine($"├─ Nombre: {ship.Name}");
        Console.WriteLine($"├─ Modelo: {ship.Model}");
        Console.WriteLine($"├─ Capacidad de Tripulación: {ship.CrewCapacity}");
        Console.WriteLine($"└─ Estado: {ship.Status}");
    }

    Console.WriteLine("\n\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void UpdateShip()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                    ACTUALIZAR NAVE");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID de la nave a actualizar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var existing = shipRepository.GetShipById(id);
    if (existing == null)
    {
        Console.WriteLine($"\n❌ No se encontró nave con ID {id}.");
        Console.ReadLine();
        return;
    }

    Console.Write("\nNuevo nombre (dejar en blanco para no cambiar): ");
    string? newName = Console.ReadLine();

    Console.Write("Nuevo modelo (dejar en blanco para no cambiar): ");
    string? newModel = Console.ReadLine();

    Console.Write("Nueva capacidad de tripulación (0 para no cambiar): ");
    int newCapacity = int.Parse(Console.ReadLine() ?? "0");

    if (newCapacity < 0)
    {
        Console.WriteLine("\n❌ Error: La capacidad de nave no puede ser negativa.");
        Console.ReadLine();
        return;
    }

    var updateShip = new Ships
    {
        Name = string.IsNullOrWhiteSpace(newName) ? null : newName,
        Model = string.IsNullOrWhiteSpace(newModel) ? null : newModel,
        CrewCapacity = newCapacity > 0 ? newCapacity : null
    };

    shipRepository.UpdateShips(id, updateShip);
    Console.WriteLine("\n✅ Nave actualizada exitosamente. Presiona Enter para continuar...");
    Console.ReadLine();
}

void DeleteShip()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                    ELIMINAR NAVE");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID de la nave a eliminar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    bool result = shipRepository.DeleteShip(id);

    if (result)
    {
        Console.WriteLine($"\n✅ Nave con ID {id} eliminada exitosamente.");
    }
    else
    {
        Console.WriteLine($"\n❌ No se encontró nave con ID {id}.");
    }

    Console.WriteLine("\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void ManageMissions()
{
    bool inMenu = true;
    while (inMenu)
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        Console.WriteLine("                    GESTIÓN DE MISIONES");
        Console.WriteLine("═══════════════════════════════════════════════════════════\n");
        Console.WriteLine("1. Crear Misión");
        Console.WriteLine("2. Listar Misiones");
        Console.WriteLine("3. Buscar Misión por ID");
        Console.WriteLine("4. Actualizar Misión");
        Console.WriteLine("5. Eliminar Misión");
        Console.WriteLine("0. Volver al Menú Principal\n");
        Console.Write("Selecciona una opción: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateMission();
                break;
            case "2":
                ListMissions();
                break;
            case "3":
                GetMissionById();
                break;
            case "4":
                UpdateMission();
                break;
            case "5":
                DeleteMission();
                break;
            case "0":
                inMenu = false;
                break;
            default:
                Console.WriteLine("\nOpción no válida. Presiona Enter para continuar...");
                Console.ReadLine();
                break;
        }
    }
}

void CreateMission()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                    CREAR MISIÓN");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Nombre de la misión: ");
    string? name = Console.ReadLine();

    Console.Write("Fecha de lanzamiento (yyyy-MM-dd): ");
    DateTime launchDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString("yyyy-MM-dd"));

    Console.WriteLine("\nEstado de la misión:");
    Console.WriteLine("0. Planned (Planificada)");
    Console.WriteLine("1. InProgress (En Curso)");
    Console.WriteLine("2. Completed (Completada)");
    Console.WriteLine("3. Failed (Fallida)");
    Console.Write("Selecciona el estado: ");

    int statusChoice = int.Parse(Console.ReadLine() ?? "0");
    MissionStatus status = (MissionStatus)statusChoice;

    Console.Write("\nID del astronauta (presione Enter si desea asignarlo después): ");
    string? astronautIdStr = Console.ReadLine();
    int? astronautId = string.IsNullOrWhiteSpace(astronautIdStr) ? null : int.Parse(astronautIdStr);

    Console.Write("ID de la nave (presione Enter si desea asignarlo después): ");
    string? shipIdStr = Console.ReadLine();
    int? shipId = string.IsNullOrWhiteSpace(shipIdStr) ? null : int.Parse(shipIdStr);

    // Validación de referencias
    if (astronautId.HasValue && astronautRepository.GetAstronautById(astronautId.Value) == null)
    {
        Console.WriteLine("\n❌ Error: El astronauta especificado no existe.");
        Console.ReadLine();
        return;
    }

    if (shipId.HasValue && shipRepository.GetShipById(shipId.Value) == null)
    {
        Console.WriteLine("\n❌ Error: La nave especificada no existe.");
        Console.ReadLine();
        return;
    }

    var mission = new Missions
    {
        Name = name,
        LaunchDate = launchDate,
        Status = status,
        AstronautId = astronautId,
        ShipId = shipId
    };

    missionRepository.AddMission(mission);
    Console.WriteLine("\n✅ Misión creada exitosamente. Presiona Enter para continuar...");
    Console.ReadLine();
}

void ListMissions()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                    LISTA DE MISIONES");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    var missions = missionRepository.GetMissions();

    if (!missions.Any())
    {
        Console.WriteLine("No hay misiones registradas.");
    }
    else
    {
        foreach (var mission in missions)
        {
            Console.WriteLine($"\n┌─ ID: {mission.Id}");
            Console.WriteLine($"├─ Nombre: {mission.Name}");
            Console.WriteLine($"├─ Fecha de Lanzamiento: {mission.LaunchDate:yyyy-MM-dd}");
            Console.WriteLine($"├─ Estado: {mission.Status}");
            Console.WriteLine($"├─ ID Astronauta: {mission.AstronautId ?? 0}");
            Console.WriteLine($"└─ ID Nave: {mission.ShipId ?? 0}");
        }
    }

    Console.WriteLine("\n\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void GetMissionById()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("              BUSCAR MISIÓN POR ID");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID de la misión: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var mission = missionRepository.GetMissionById(id);

    if (mission == null)
    {
        Console.WriteLine($"\n❌ No se encontró misión con ID {id}.");
    }
    else
    {
        Console.WriteLine($"\n✅ Misión encontrada:");
        Console.WriteLine($"\n┌─ ID: {mission.Id}");
        Console.WriteLine($"├─ Nombre: {mission.Name}");
        Console.WriteLine($"├─ Fecha de Lanzamiento: {mission.LaunchDate:yyyy-MM-dd}");
        Console.WriteLine($"├─ Estado: {mission.Status}");
        Console.WriteLine($"├─ ID Astronauta: {mission.AstronautId ?? 0}");
        Console.WriteLine($"└─ ID Nave: {mission.ShipId ?? 0}");
    }

    Console.WriteLine("\n\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void UpdateMission()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                  ACTUALIZAR MISIÓN");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID de la misión a actualizar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var existing = missionRepository.GetMissionById(id);
    if (existing == null)
    {
        Console.WriteLine($"\n❌ No se encontró misión con ID {id}.");
        Console.ReadLine();
        return;
    }

    Console.Write("\nNuevo nombre (dejar en blanco para no cambiar): ");
    string? newName = Console.ReadLine();

    Console.Write("Nueva fecha de lanzamiento en formato yyyy-MM-dd (dejar en blanco para no cambiar): ");
    string? dateStr = Console.ReadLine();
    DateTime? newDate = string.IsNullOrWhiteSpace(dateStr) ? null : DateTime.Parse(dateStr);

    Console.Write("Nuevo estado de la misión (dejar en blanco para no cambiar): ");
    string? statusStr = Console.ReadLine();
    int? newStatusChoice = string.IsNullOrWhiteSpace(statusStr) ? null : int.Parse(statusStr);
    MissionStatus? newStatus = newStatusChoice.HasValue ? (MissionStatus)newStatusChoice.Value : null;

    var updateMission = new Missions
    {
        Name = string.IsNullOrWhiteSpace(newName) ? null : newName,
        LaunchDate = newDate,
        Status = newStatus ?? default
    };

    missionRepository.UpdateMission(id, updateMission);
    Console.WriteLine("\n✅ Misión actualizada exitosamente. Presiona Enter para continuar...");
    Console.ReadLine();
}

void DeleteMission()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("                  ELIMINAR MISIÓN");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID de la misión a eliminar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    bool result = missionRepository.DeleteMission(id);

    if (result)
    {
        Console.WriteLine($"\n✅ Misión con ID {id} eliminada exitosamente.");
    }
    else
    {
        Console.WriteLine($"\n❌ No se encontró misión con ID {id}.");
    }

    Console.WriteLine("\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void ManageExplorationLogs()
{
    bool inMenu = true;
    while (inMenu)
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        Console.WriteLine("              GESTIÓN DE REGISTROS DE EXPLORACIÓN");
        Console.WriteLine("═══════════════════════════════════════════════════════════\n");
        Console.WriteLine("1. Crear Registro de Exploración");
        Console.WriteLine("2. Listar Registros de Exploración");
        Console.WriteLine("3. Buscar Registro de Exploración por ID");
        Console.WriteLine("4. Actualizar Registro de Exploración");
        Console.WriteLine("5. Eliminar Registro de Exploración");
        Console.WriteLine("0. Volver al Menú Principal\n");
        Console.Write("Selecciona una opción: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateExplorationLog();
                break;
            case "2":
                ListExplorationLogs();
                break;
            case "3":
                GetExplorationLogById();
                break;
            case "4":
                UpdateExplorationLog();
                break;
            case "5":
                DeleteExplorationLog();
                break;
            case "0":
                inMenu = false;
                break;
            default:
                Console.WriteLine("\nOpción no válida. Presiona Enter para continuar...");
                Console.ReadLine();
                break;
        }
    }
}

void CreateExplorationLog()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("              CREAR REGISTRO DE EXPLORACIÓN");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Planeta de destino: ");
    string? planet = Console.ReadLine();

    Console.Write("Descripción: ");
    string? description = Console.ReadLine();

    Console.WriteLine("\nNivel de Riesgo:");
    Console.WriteLine("0. Low (Bajo)");
    Console.WriteLine("1. Medium (Medio)");
    Console.WriteLine("2. High (Alto)");
    Console.Write("Selecciona el nivel de riesgo: ");

    int riskChoice = int.Parse(Console.ReadLine() ?? "0");
    RiskLevel riskLevel = (RiskLevel)riskChoice;

    Console.Write("\nID de la misión asociada: ");
    int missionId = int.Parse(Console.ReadLine() ?? "0");

    // Validación de referencia
    if (missionRepository.GetMissionById(missionId) == null)
    {
        Console.WriteLine("\n❌ Error: La misión especificada no existe.");
        Console.ReadLine();
        return;
    }

    var explorationLog = new ExplorationLogs
    {
        DestinyPlanet = planet,
        Description = description,
        RiskLevel = riskLevel,
        MissionId = missionId
    };

    explorationLogRepository.AddExplorationLog(explorationLog);
    Console.WriteLine("\n✅ Registro de exploración creado exitosamente. Presiona Enter para continuar...");
    Console.ReadLine();
}

void ListExplorationLogs()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("              LISTA DE REGISTROS DE EXPLORACIÓN");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    var explorationLogs = explorationLogRepository.GetExplorationLogs();

    if (!explorationLogs.Any())
    {
        Console.WriteLine("No hay registros de exploración registrados.");
    }
    else
    {
        foreach (var log in explorationLogs)
        {
            Console.WriteLine($"\n┌─ ID: {log.Id}");
            Console.WriteLine($"├─ Planeta de Destino: {log.DestinyPlanet}");
            Console.WriteLine($"├─ Descripción: {log.Description}");
            Console.WriteLine($"├─ Nivel de Riesgo: {log.RiskLevel}");
            Console.WriteLine($"└─ ID de Misión: {log.MissionId}");
        }
    }

    Console.WriteLine("\n\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void GetExplorationLogById()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("        BUSCAR REGISTRO DE EXPLORACIÓN POR ID");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID del registro de exploración: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var log = explorationLogRepository.GetExplorationLogById(id);

    if (log == null)
    {
        Console.WriteLine($"\n❌ No se encontró registro de exploración con ID {id}.");
    }
    else
    {
        Console.WriteLine($"\n✅ Registro de exploración encontrado:");
        Console.WriteLine($"\n┌─ ID: {log.Id}");
        Console.WriteLine($"├─ Planeta de Destino: {log.DestinyPlanet}");
        Console.WriteLine($"├─ Descripción: {log.Description}");
        Console.WriteLine($"├─ Nivel de Riesgo: {log.RiskLevel}");
        Console.WriteLine($"└─ ID de Misión: {log.MissionId}");
    }

    Console.WriteLine("\n\nPresiona Enter para continuar...");
    Console.ReadLine();
}

void UpdateExplorationLog()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("            ACTUALIZAR REGISTRO DE EXPLORACIÓN");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID del registro a actualizar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    var existing = explorationLogRepository.GetExplorationLogById(id);
    if (existing == null)
    {
        Console.WriteLine($"\n❌ No se encontró registro de exploración con ID {id}.");
        Console.ReadLine();
        return;
    }

    Console.Write("\nNuevo planeta de destino (dejar en blanco para no cambiar): ");
    string? newPlanet = Console.ReadLine();

    Console.Write("Nueva descripción (dejar en blanco para no cambiar): ");
    string? newDescription = Console.ReadLine();

    var updateLog = new ExplorationLogs
    {
        DestinyPlanet = string.IsNullOrWhiteSpace(newPlanet) ? null : newPlanet,
        Description = string.IsNullOrWhiteSpace(newDescription) ? null : newDescription
    };

    explorationLogRepository.UpdateExplorationLog(id, updateLog);
    Console.WriteLine("\n✅ Registro de exploración actualizado exitosamente. Presiona Enter para continuar...");
    Console.ReadLine();
}

void DeleteExplorationLog()
{
    Console.Clear();
    Console.WriteLine("═══════════════════════════════════════════════════════════");
    Console.WriteLine("            ELIMINAR REGISTRO DE EXPLORACIÓN");
    Console.WriteLine("═══════════════════════════════════════════════════════════\n");

    Console.Write("Ingresa el ID del registro a eliminar: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    bool result = explorationLogRepository.DeleteExplorationLog(id);

    if (result)
    {
        Console.WriteLine($"\n✅ Registro de exploración con ID {id} eliminado exitosamente.");
    }
    else
    {
        Console.WriteLine($"\n❌ No se encontró registro de exploración con ID {id}.");
    }

    Console.WriteLine("\nPresiona Enter para continuar...");
    Console.ReadLine();
}
