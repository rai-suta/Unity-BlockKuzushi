using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Bricks : MonoBehaviour
{
    public string prefabAssetPath;
    public GameObject Brick_prefab;
    public int ColNum;
    public int RowNum;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    // Inspector のパラメータを変更してすぐにコンテキストメニューを実行すると、
    // パラメータが変更前の値に戻ってしまう。
    // これを防止するには、パラメータ変更後に一度Enterキーで入力値を確定させてから、
    // コンテキストメニューを実行する必要がある。
    [ContextMenu("UpdateBricks")]
    private void UpdateBricks()
    {
        // 編集対象のプレハブを読み込む
        var rootObject = PrefabUtility.LoadPrefabContents(prefabAssetPath);
        {
            // 古いインスタンスをすべて削除
            var old = new Stack<GameObject>();
            foreach (Transform child in rootObject.transform) old.Push(child.gameObject);
            while (old.Count > 0) DestroyImmediate(old.Pop());

            // プレハブから新しいインスタンスを作成
            var prefab = Brick_prefab;
            var prefab_size = prefab.transform.lossyScale;
            var wall_top_pos = new Vector3(-prefab_size.x * (ColNum-1) / 2, -prefab_size.y * (RowNum-1) / 2, 0f);
            for (int j = 0; j < RowNum; j++)
            {
                for (int i = 0; i < ColNum; i++)
                {
                    var position = wall_top_pos + Vector3.Scale(prefab_size, new Vector3(i, j, 0f));
                    var child = GameObject.Instantiate(prefab, position, Quaternion.identity);
                    child.SetActive(true);
                    child.transform.SetParent(rootObject.transform);
                }
            }
        }

        // 編集完了したプレハブを保存する
        PrefabUtility.SaveAsPrefabAsset(rootObject, prefabAssetPath);
        PrefabUtility.UnloadPrefabContents(rootObject);
    }

}
