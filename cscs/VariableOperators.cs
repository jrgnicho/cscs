using System;
using System.Linq.Expressions;

namespace SplitAndMerge
{
    public partial class Variable
    {
        /// <summary>
        /// Converts a Variable into a ConstantExpression that can be used within an Expression tree.
        /// </summary>
        /// <returns>A ConstantExpression of the correct type as indicated by the OriginalType field of this Variable.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the conversion is not possible.</exception>
        public ConstantExpression ToExpression()
        {
            switch (this.Original)
            {
                case Variable.OriginalType.INT:
                    return Expression.Constant(this.AsInt());
                case Variable.OriginalType.LONG:
                    return Expression.Constant(this.AsLong());
                case Variable.OriginalType.BOOL:
                    return Expression.Constant(this.AsBool());
                case Variable.OriginalType.DOUBLE:
                    return Expression.Constant(this.AsDouble());
                case Variable.OriginalType.STRING:
                    return Expression.Constant(this.AsString());
            }
            return Expression.Constant(null, typeof(string));
        }

        public static explicit operator bool(Variable variable)
        {
            return variable.AsBool();
        }

        public static explicit operator int(Variable variable)
        {
            return variable.AsInt();
        }

        public static explicit operator float(Variable variable)
        {
            return variable.AsFloat();
        }

        public static explicit operator double(Variable variable)
        {
            return variable.AsDouble();
        }

        public static explicit operator string(Variable variable)
        {
            return variable.AsString();
        }

        public static implicit operator Variable(int val)
        {
            return new Variable(val);
        }

        public static implicit operator Variable(bool val)
        {
            return new Variable(val);
        }

        public static implicit operator Variable(float val)
        {
            return new Variable(val);
        }

        public static implicit operator Variable(double val)
        {
            return new Variable(val);
        }

        public static implicit operator Variable(string val)
        {
            return new Variable(val);
        }
        
       public static Variable operator +(Variable a, Variable b)
        {
            if (a.Type == VarType.NUMBER && b.Type == VarType.NUMBER)
            {
                return new Variable(a.AsDouble() + b.AsDouble());
            }
            else if (a.Type == VarType.STRING && b.Type == VarType.STRING)
            {
                return new Variable(a.AsString() + b.AsString());
            }
            else
            {
                throw new InvalidOperationException("Operator + is not defined for these types");
            }
        }

        public static Variable operator -(Variable a, Variable b)
        {
            if (a.Type == VarType.NUMBER && b.Type == VarType.NUMBER)
            {
                return new Variable(a.AsDouble() - b.AsDouble());
            }
            else
            {
                throw new InvalidOperationException("Operator - is not defined for these types");
            }
        }

        public static Variable operator *(Variable a, Variable b)
        {
            if (a.Type == VarType.NUMBER && b.Type == VarType.NUMBER)
            {
                return new Variable(a.AsDouble() * b.AsDouble());
            }
            else
            {
                throw new InvalidOperationException("Operator * is not defined for these types");
            }
        }

        public static Variable operator /(Variable a, Variable b)
        {
            if (a.Type == VarType.NUMBER && b.Type == VarType.NUMBER)
            {
                if (b.AsDouble() == 0)
                {
                    throw new DivideByZeroException();
                }
                return new Variable(a.AsDouble() / b.AsDouble());
            }
            else
            {
                throw new InvalidOperationException("Operator / is not defined for these types");
            }
        }

        public static Variable operator %(Variable a, Variable b)
        {
            if (a.Type == VarType.NUMBER && b.Type == VarType.NUMBER)
            {
                return new Variable(a.AsDouble() % b.AsDouble());
            }
            else
            {
                throw new InvalidOperationException("Operator % is not defined for these types");
            }
        }

        public static bool operator >(Variable a, Variable b)
        {
            if (a.Type == VarType.NUMBER && b.Type == VarType.NUMBER)
            {
                return a.AsDouble() > b.AsDouble();
            }
            else if (a.Type == VarType.STRING && b.Type == VarType.STRING)
            {
                return string.Compare(a.AsString(), b.AsString()) > 0;
            }
            else
            {
                throw new InvalidOperationException("Operator > is not defined for these types");
            }
        }

        public static bool operator <(Variable a, Variable b)
        {
            if (a.Type == VarType.NUMBER && b.Type == VarType.NUMBER)
            {
                return a.AsDouble() < b.AsDouble();
            }
            else if (a.Type == VarType.STRING && b.Type == VarType.STRING)
            {
                return string.Compare(a.AsString(), b.AsString()) < 0;
            }
            else
            {
                throw new InvalidOperationException("Operator < is not defined for these types");
            }
        }

        public static bool operator >=(Variable a, Variable b)
        {
            if (a.Type == VarType.NUMBER && b.Type == VarType.NUMBER)
            {
                return a.AsDouble() >= b.AsDouble();
            }
            else if (a.Type == VarType.STRING && b.Type == VarType.STRING)
            {
                return string.Compare(a.AsString(), b.AsString()) >= 0;
            }
            else
            {
                throw new InvalidOperationException("Operator >= is not defined for these types");
            }
        }

        public static bool operator <=(Variable a, Variable b)
        {
            if (a.Type == VarType.NUMBER && b.Type == VarType.NUMBER)
            {
                return a.AsDouble() <= b.AsDouble();
            }
            else if (a.Type == VarType.STRING && b.Type == VarType.STRING)
            {
                return string.Compare(a.AsString(), b.AsString()) <= 0;
            }
            else
            {
                throw new InvalidOperationException("Operator <= is not defined for these types");
            }
        }

        public static bool operator ==(Variable a, Variable b)
        {
            if (a.Type == VarType.NUMBER && b.Type == VarType.NUMBER)
            {
                return a.AsDouble() == b.AsDouble();
            }
            else if (a.Type == VarType.STRING && b.Type == VarType.STRING)
            {
                return a.AsString() == b.AsString();
            }
            else
            {
                throw new InvalidOperationException("Operator == is not defined for these types");
            }
        }

        public static bool operator !=(Variable a, Variable b)
        {
            return !(a == b);
        }

        public static bool operator | (Variable a, Variable b)
        {
            if (a.Type == VarType.INT && b.Type == VarType.INT)
            {
                return a.AsBool() || b.AsBool(); 
                
            }
            throw new InvalidOperationException("Operator | is not defined for these types");
        }

        public static bool operator & (Variable a, Variable b)
        {
            if (a.Type == VarType.INT && b.Type == VarType.INT)
            {
                return a.AsBool() && b.AsBool(); 
                
            }
            throw new InvalidOperationException("Operator & is not defined for these types");
        }
    }
}