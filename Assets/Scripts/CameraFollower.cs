using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private int _leftLimitLine = -480;
    private int _rightLimitLine = 480;
    private Vector3 _preMousePos;

    /// <summary>
    /// 中クリック押下時に座標を取得し続ける
    /// </summary>
    private void MouseUpdate()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.MiddleMouse))
            _preMousePos = Input.mousePosition;

        MouseDrag(Input.mousePosition);
        ClampCameraPosition();
    }

    /// <summary>
    /// カメラの移動範囲の制限
    /// </summary>
    void ClampCameraPosition()
    {
        if (this.transform.position.x < _leftLimitLine)
            this.transform.position
                = new Vector3(_leftLimitLine, this.transform.position.y, this.transform.position.z);

        if (_rightLimitLine < this.transform.position.x)
            this.transform.position
               = new Vector3(_rightLimitLine, this.transform.position.y, this.transform.position.z);
    }

    /// <summary>
    /// 中クリックを押しているときのみ視点移動
    /// </summary>
    private void MouseDrag(Vector3 mousePos)
    {
        //　現時点の座標と獲得しているフレームの差分を移動量とする
        Vector3 diff = mousePos - _preMousePos;

        // 差分値が極小値より小さければ、ドラッグしていないとする
        if (diff.magnitude < Vector3.kEpsilon)
            return;

        if (Input.GetMouseButton((int)MouseButton.MiddleMouse))
            transform.Translate(new Vector3(-diff.x * Time.deltaTime * _moveSpeed, 0));

        _preMousePos = mousePos;
    }

    private void Update()
    {
        MouseUpdate();
    }
}