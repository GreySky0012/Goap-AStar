using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Context {
    void Update();
    bool Contain(Context context);
}