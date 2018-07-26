using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HouraiTeahouse.Options {

public interface IOptionsStorage {
  bool IsOptionSet(string path);
  void SaveOption(string path, float value);
  float GetOption(string path);
  void SaveChanges();
}

}