using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK.GameStructure
{
    public class StateSystem : IGameObject
    {
        private IDictionary<string, IGameObject> _stateStore = new Dictionary<string, IGameObject>();
        private IGameObject _currentState = null;

        public void Update(double elapsedTime)
        {
            if (_currentState == null) return;

            _currentState.Update(elapsedTime);
        }

        public void Render()
        {
            if (_currentState == null) return;

            _currentState.Render();
        }

        public void AddState(string stateId, IGameObject state)
        {
            Debug.Assert(!Exists(stateId));
            _stateStore.Add(stateId, state);
        }

        public void ChangeState(string stateId)
        {
            Debug.Assert(Exists(stateId));
            _currentState = _stateStore[stateId];
        }

        public bool Exists(string stateId)
        {
            return _stateStore.ContainsKey(stateId);
        }
    }
}
