using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Character : IAttacker, IHp
    {
        public string? NickName { get; set; }


        public float Exp
        {
            get
            {
                return _exp;
            }
            private set
            {
                if (value < 0)
                    value = 0;
                _exp = value;
            }
        }

        public float AttackPower
        {
            get
            {
                return _attackPower;
            }
        }

        public float HpValue => throw new NotImplementedException();

        public float HpMax => throw new NotImplementedException();

        public float HpMin => throw new NotImplementedException();

        private float _exp;
        private float _attackPower;

        //=================================================================================
        //                                 Public Methods
        //=================================================================================

        public float GetExp()
        {
            return _exp;
        }
        
        public void SetExp(float value)
        {
            if (value < 0) 
                value = 0;
            _exp = value;
        }


        public void Jump()
        {
            Console.WriteLine("Jump!");
        }

        public void Attack(IHp target)
        {
          target.DepleteHp(_attackPower);
        }

        public void RecoverHp(float value)
        {
            throw new NotImplementedException();
        }

        public void DepleteHp(float value)
        {
            throw new NotImplementedException();
        }

        //=================================================================================
        //                                 Private Methods
        //=================================================================================
    }

}