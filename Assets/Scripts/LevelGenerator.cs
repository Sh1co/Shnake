using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private int _piecesCount = 5;
        [SerializeField] private float _minPieceSize = 5f;
        [SerializeField] private float _maxPieceSize = 25f;
        [SerializeField] private GameObject _dir1Piece;
        [SerializeField] private GameObject _dir2Piece;
        [SerializeField] private Vector3 _piecesShift = new Vector3(-0.5f, 0, 0.5f);
        [SerializeField] private GameObject _finishLine;
        [SerializeField] private GameObject _coin;
        [SerializeField] private LevelCounter _levelCounter;
        
        public void GenerateLevel()
        {
            ClearLevel();
            
            // To make levels get a bit harder
            int pieceCountWithExtras = _piecesCount + (_levelCounter.Level / 50);
            
            bool dir1 = true;
            Vector3 startPoint = new Vector3(0, -1, 0);
            for (int i = 0; i < pieceCountWithExtras; i++)
            {
                float pieceSize = Random.Range(_minPieceSize, _maxPieceSize);
                var coinDistance = Random.Range((-pieceSize / 2) + 0.5f, (pieceSize / 2) - 0.5f);
                
                if (dir1)
                {
                    var piece = Instantiate(_dir1Piece);
                    piece.transform.SetParent(_level.transform);
                    var newScale = piece.transform.localScale;
                    newScale.z = pieceSize;
                    piece.transform.localScale = newScale;
                    
                    startPoint.z += pieceSize / 2;
                    piece.transform.position = startPoint;

                    var coinPos = startPoint;
                    coinPos.z += coinDistance;
                    coinPos.y = 0;
                    var coin = Instantiate(_coin, coinPos, _coin.transform.rotation);
                    coin.transform.SetParent(_level.transform);
                    
                    startPoint.z += pieceSize / 2;
                    startPoint += _piecesShift;
                }
                else
                {
                    var piece = Instantiate(_dir2Piece);
                    piece.transform.SetParent(_level.transform);
                    var newScale = piece.transform.localScale;
                    newScale.z = pieceSize;
                    piece.transform.localScale = newScale;
                    
                    startPoint.x -= pieceSize / 2;
                    piece.transform.position = startPoint;
                    
                    var coinPos = startPoint;
                    coinPos.x -= coinDistance;
                    coinPos.y = 0;
                    var coin = Instantiate(_coin, coinPos, _coin.transform.rotation);
                    coin.transform.SetParent(_level.transform);
                    
                    startPoint.x -= pieceSize / 2;
                    startPoint += _piecesShift;
                }
                dir1 = !dir1;
            }

            var finishLine = Instantiate(_finishLine, startPoint - _piecesShift, Quaternion.identity);
            finishLine.GetComponent<FinishTrigger>().LevelGenerator = this;
            finishLine.GetComponent<FinishTrigger>().LevelCounter = _levelCounter;
            finishLine.transform.SetParent(_level.transform);
            
        }

        private void Start()
        {
            GenerateLevel();
        }
        
        private void ClearLevel()
        {
            if(null != _level)
                Destroy(_level);
            _level = new GameObject("Level");
        }

        private GameObject _level;
    }
}