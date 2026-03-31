using System;

namespace Transporturi.Entitati
{
    [Flags]
    public enum OptiuniMasina
    {
        Niciuna = 0,
        AerConditionat = 1,
        Navigatie = 2,
        CutieAutomata = 4,
        SenzoriParcare = 8
    }
}