using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0.Models
{
    public class PairSchedule
    {
        protected bool Equals(PairSchedule other)
        {
            return _pairNumber == other._pairNumber && _day == other._day;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PairSchedule) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_pairNumber, _day);
        }

        // 08:20-09:50 ==> 1
        // 10:00-11:30 ==> 2
        // 11:40-13:10 ==> 3
        // 13:30-15:00 ==> 4
        // 15:20-16:50 ==> 5
        // 17:00-18:30 ==> 6
        // 18:40-20:10 ==> 7
        // 20:20-21:50 ==> 8
        private int _pairNumber;
        public int PairNumber {
            get => _pairNumber;
            set {
                if (value >= 1 && value <= 8) {
                    _pairNumber = value;
                }
            }
        } // from 1 to 8

        private int _day;
        public int Day {
            get => _day;
            set {
                if (value >= 1 && value <= 14) {
                    _day = value;
                }
            }
        } // from 1 to 14 (каждые 2 недели повторение)

        public static bool operator ==(PairSchedule p1, PairSchedule p2)
        {
            return p1?.Day == p2?.Day && p1?.PairNumber == p2?.PairNumber;
        }

        public static bool operator !=(PairSchedule p1, PairSchedule p2)
        {
            return !(p1 == p2);
        }
    }
}
