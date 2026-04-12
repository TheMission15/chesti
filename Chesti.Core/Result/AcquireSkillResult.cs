using Chesti.Core.Model;

namespace Chesti.Core.Result
{
    public class AcquireSkillResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public Skill Skill { get; set; }
        public bool Droppable { get; set; }
        public AcquireSkillResult(bool result, string message, Skill skill, bool droppable)
        {
            Result = result; Message = message; Skill = skill; Droppable = droppable;
        }
    }
}
