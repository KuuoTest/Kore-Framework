using System;

namespace Kore
{
    public enum ValueComparison
    {
        Less,
        LessOrEqual,
        Greater,
        GreaterOrEqual,
        Equal,
        NotEqual,
    }

    public static class ValueComparisonExtension
    {
        public static bool Check<T>(this ValueComparison comp, T lhs, T rhs)
            where T : IComparable<T>
        {
            switch (comp)
            {
                case ValueComparison.Less:
                    return lhs.CompareTo(rhs) < 0;
                case ValueComparison.LessOrEqual:
                    return lhs.CompareTo(rhs) <= 0;
                case ValueComparison.Greater:
                    return lhs.CompareTo(rhs) > 0;
                case ValueComparison.GreaterOrEqual:
                    return lhs.CompareTo(rhs) >= 0;
                case ValueComparison.Equal:
                    return lhs.CompareTo(rhs) == 0;
                case ValueComparison.NotEqual:
                    return lhs.CompareTo(rhs) != 0;
            }
            return false;
        }
    }
}