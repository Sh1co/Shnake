using System;
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

        private void Start()
        {
            bool dir1 = true;
            Vector3 startPoint = new Vector3(0, -1, 0);
            for (int i = 0; i < _piecesCount; i++)
            {
                float pieceSize = Random.Range(_minPieceSize, _maxPieceSize);
                var coinDistance = Random.Range((-pieceSize / 2) + 0.5f, (pieceSize / 2) - 0.5f);
                
                if (dir1)
                {
                    var piece = Instantiate(_dir1Piece);
                    var newScale = piece.transform.localScale;
                    newScale.z = pieceSize;
                    piece.transform.localScale = newScale;
                    
                    startPoint.z += pieceSize / 2;
                    piece.transform.position = startPoint;

                    var coinPos = startPoint;
                    coinPos.z += coinDistance;
                    coinPos.y = 0;
                    Instantiate(_coin, coinPos, _coin.transform.rotation);
                    
                    startPoint.z += pieceSize / 2;
                    startPoint += _piecesShift;
                }
                else
                {
                    var piece = Instantiate(_dir2Piece);
                    var newScale = piece.transform.localScale;
                    newScale.z = pieceSize;
                    piece.transform.localScale = newScale;
                    
                    startPoint.x -= pieceSize / 2;
                    piece.transform.position = startPoint;
                    
                    var coinPos = startPoint;
                    coinPos.x -= coinDistance;
                    coinPos.y = 0;
                    Instantiate(_coin, coinPos, _coin.transform.rotation);
                    
                    startPoint.x -= pieceSize / 2;
                    startPoint += _piecesShift;
                }
                dir1 = !dir1;
            }

            Instantiate(_finishLine, startPoint - _piecesShift, Quaternion.identity);

        }
    }
}