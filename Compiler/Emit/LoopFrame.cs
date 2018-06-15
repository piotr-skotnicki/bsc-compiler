using System;
using System.Reflection.Emit;

namespace Compiler.Emit
{
    public class LoopFrame
    {
        public Label BreakLabel { get; private set; }
        public Label ContinueLabel { get; private set; }

        public LoopFrame(
            Label break_label,
            Label continue_label)
        {
            this.BreakLabel = break_label;
            this.ContinueLabel = continue_label;
        }
    }
}
