using System;
using System.Linq;

namespace safari
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("ON SAFARI");

      var db = new SafariVacationContext();

      var lion = new Animal
      {
        Species = "Lion",
        CountOfTimesSeen = 2,
        LocationOfLastSeen = "Jungle"
      };
      var tiger = new Animal
      {
        Species = "Tiger",
        CountOfTimesSeen = 1,
        LocationOfLastSeen = "Jungle"
      };
      var bear = new Animal
      {
        Species = "Bear",
        CountOfTimesSeen = 0,
        LocationOfLastSeen = "Jungle"
      };
      var elephant = new Animal
      {
        Species = "Elephant",
        CountOfTimesSeen = 0,
        LocationOfLastSeen = "Desert"
      };
      var rhino = new Animal
      {
        Species = "Rhinoceros",
        CountOfTimesSeen = 1,
        LocationOfLastSeen = "Desert"
      };
      db.SeenAnimals.Add(lion);
      db.SeenAnimals.Add(tiger);
      db.SeenAnimals.Add(bear);
      db.SeenAnimals.Add(elephant);
      db.SeenAnimals.Add(rhino);
      db.SaveChanges();

      //Display all animals the user has seen
      var animalsSeen = db.SeenAnimals.Where(animal => animal.CountOfTimesSeen > 0);
      foreach (var animal in animalsSeen)
      {
        Console.WriteLine("I've seen " + animal.Species);
      }
      //Update the CountOfTimesSeen and LocationOfLastSeen for an animal
      var rhinos = db.SeenAnimals.FirstOrDefault(animal => animal.Id == 5);
      if (rhinos != null)
      {
        rhinos.LocationOfLastSeen = "Jungle";
        rhinos.CountOfTimesSeen = 3;
      }
      db.SaveChanges();
      //Display all animals seen in the Jungle
      var jungleSeen = db.SeenAnimals.Where(animal => animal.CountOfTimesSeen > 0 && animal.LocationOfLastSeen == "Jungle");
      foreach (var animal in jungleSeen)
      {
        Console.WriteLine("I saw " + animal.Species + " in the jungle.");
      }
      //Remove all animals that I have seen in the Desert.
      var desertSeen = db.SeenAnimals.Where(animal => animal.LocationOfLastSeen == "Desert");
      foreach (var animal in desertSeen)
      {
        db.SeenAnimals.Remove(animal);
      }
      db.SaveChanges();
      //Add all the CountOfTimesSeen and get a total number of animals seen
      var totalSeen = 0;
      foreach (var animal in animalsSeen)
      {
        totalSeen += animal.CountOfTimesSeen;
      }
      Console.WriteLine("I saw " + totalSeen + " animals in all.");
      //Get the CountOfTimesSeen of lions, tigers and bears
      var ohMy = db.SeenAnimals.Where(animal => animal.Id == 1 || animal.Id == 2 || animal.Id == 3);
      foreach (var animal in ohMy)
      {
        Console.WriteLine("I've seen " + animal.CountOfTimesSeen + " " + animal.Species);
      }
      //Removing accidentally added duplicate animals
      var duplicates = db.SeenAnimals.Where(animal => animal.Id > 5);
      foreach (var animal in duplicates)
      {
        db.SeenAnimals.Remove(animal);
      }
      db.SaveChanges();
    }
  }
}
