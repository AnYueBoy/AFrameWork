﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoUtil : MonoBehaviour {

    public void deleay (float time, Action onFinished) {
        StartCoroutine (deleayCoroutine (time, onFinished));
    }

    private IEnumerator deleayCoroutine (float time, Action finished) {
        yield return new WaitForSeconds (time);
        finished ();
    }

    private Vector2[] pathList = null;

    /// <summary>
    /// 绘制路径
    /// </summary>
    /// <param name="path">路径信息</param>
    protected void drawLine (Vector2[] path) {
        this.pathList = path;
    }

    private void OnDrawGizmos () {
        if (this.pathList == null || this.pathList.Length <= 0) {
            return;
        }

        Color orginColor = Gizmos.color;
        Gizmos.color = Color.red;
        for (int i = 0; i < this.pathList.Length; i++) {
            Vector2 point = this.pathList[i];
            Gizmos.DrawSphere (point, 0.2f);
        }

        Gizmos.color = Color.yellow;
        for (int i = 0; i < this.pathList.Length - 1; i++) {
            Gizmos.DrawLine (this.pathList[i], this.pathList[i + 1]);
        }

        Gizmos.color = orginColor;

    }
}