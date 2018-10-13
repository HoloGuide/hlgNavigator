using UnityEngine;

public class TesterForNavigator : MonoBehaviour
{
    public LocateMap locateMap;
    public RoomLoader roomLoader;

    private Navigator nav;

    private void Start()
    {
        nav = this.GetComponent<Navigator>();

        // MapLoader.UseDist = false;
        var map = MapLoader.Load(@"F:\ziyuu29\map_test.json");
        // nav.Navigate(map, 1, 6);

        locateMap.AnchorID = map.AnchorId;
        roomLoader.RoomId = map.RoomId;   
        locateMap.Locate();

    }

    private void Update()
    {

    }
}
