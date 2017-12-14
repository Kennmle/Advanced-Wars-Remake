using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path {
  //Fields
  private int cost;
  private List<PathNode> path;

  public Path() {
    path=new List<PathNode>();
    cost=0;
  }

  public int getCost() {
    return cost;
  }

  public List<PathNode> getPath() {
      return path;
  }

  public List<Tile> getTiles() {
      List<Tile> temp=new List<Tile>();
      for(int i = 0; i<path.Count;i++)
        temp.Add(path[i].getValue());
      return temp;
  }

  public void insertHead(Tile t, int w) {
    PathNode temp= new PathNode(t,w);
    path.Insert(0,temp);
    cost+=w;
  }

  public void insertTail(Tile t, int w) {
    PathNode temp= new PathNode(t,w);
    path.Add(temp);
    cost+=w;
  }

  public int length() {
    return path.Count;
  }

  public Path getUpTo(Tile t) {
    Path temp=new Path();
    bool done=false;
    for(int i = 0; !done;i++) {
      //sanity check
      if(i>=path.Count)
        break;
      temp.insertTail(path[i].getValue(), path[i].getWeight());
      if(path[i].getValue()==t)
        done=true;
    }
    return temp;
  }

  public Path getUpTo(PathNode p) {
    return getUpTo(p.getValue());
  }

  public Path getUpTo(int i) {
    return getUpTo(path[i]);
  }

  public Path merge(Path b) {
    for(int i = 0; i<b.length(); i++)
      this.insertTail(b.at(i).getValue(),b.at(i).getWeight());
    return this;
  }

  public PathNode at(int i) {
    return path[i];
  }
}
