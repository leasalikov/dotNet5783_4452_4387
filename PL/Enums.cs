using System;
using System.Collections;
using System.Collections.Generic;

namespace PL
{
    internal class EngineersTeam : IEnumerable
    {
        static readonly IEnumerable<BO.EngineerLevelEnum> s_enums =
            (Enum.GetValues(typeof(BO.EngineerLevelEnum)) as IEnumerable<BO.EngineerLevelEnum>)!;

        public IEnumerator GetEnumerator() => s_enums.GetEnumerator();
        public BO.EngineerLevelEnum EngineerList { get; set; } = BO.EngineerLevelEnum.None;
    }
}