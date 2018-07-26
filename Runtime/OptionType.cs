using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HouraiTeahouse.Options {

/// <summary>
/// The enumeration of all supported Option types.
/// </summary>
public enum OptionType {
  
  /// <summary>
  /// A float value.
  /// </summary>
  Integer,

  /// <summary>
  /// A int value.
  /// </summary>
  Float, 

  /// <summary>
  /// A bool value.
  /// </summary>
  Boolean, 

  /// <summary>
  /// A enum value. This can support any enum type.
  /// </summary>
  Enum
}

}