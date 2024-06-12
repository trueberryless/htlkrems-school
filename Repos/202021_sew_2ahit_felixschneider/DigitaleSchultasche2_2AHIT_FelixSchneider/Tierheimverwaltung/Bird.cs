using System;
using System.Collections.Generic;
using System.Text;

namespace Tierheimverwaltung
{
    class Bird:Animal
    {
        protected int wingSpan;

        //Constructors
        public Bird() : this(0, 0) { }

        public Bird(int wingSpan) : this(wingSpan, 0) { }

        public Bird(int wingSpan, int weight) : base(weight)
        {
            this.wingSpan = wingSpan;
        }

        public override string ToString()
        {
            return $"Weight: {base.weight}kg, Wing-Span: {this.wingSpan}cm, recording-Date: {base.recordingDate}";
        }
    }
}
