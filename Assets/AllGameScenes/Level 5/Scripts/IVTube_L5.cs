using Obi;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using UnityEngine;

public class IVTube_L5 : MonoBehaviour
{
    public ObiParticleAttachment[] attachments;
    public ObiRope rope;
    // Start is called before the first frame update
    void Start()
    {

        

    }

    public void initiateTube()
    {
        print(attachments.Length);
        rope = GetComponent<ObiRope>();
        attachments = GetComponents<ObiParticleAttachment>();
        for (int i = 0; i < attachments.Length; i++)
        {

            copyAttachment(attachments[i]);
        }

    }

    public void copyAttachment(ObiParticleAttachment cloningAttachment)
    {
        //copy position
        Transform target = cloningAttachment.target;
        ObiParticleGroup group = cloningAttachment.particleGroup;
        Vector3 offset = Vector3.zero;
        if (group.name == "Head")
        {
            if (target.Find("Head"))
            {
                
                Vector3 headPos = target.Find("Head").position;
                offset = headPos - target.position;
                print(offset);
            }
        }else if(group.name == "Tail")
        {
            if (target.Find("Tail"))
            {
                print(target.position);
                Vector3 tailPos = target.Find("Tail").position;
                offset = tailPos - target.position;
                print(target.position);
            }
        }

        Vector3 newPos = target.position + offset;
        rope.solver.positions[group.particleIndices[0]] = newPos;
        print(newPos);
        //copy attachment
        var attachment = this.gameObject.AddComponent<ObiParticleAttachment>();
        attachment.target = target.transform;
        attachment.particleGroup = group;
        attachment.attachmentType = cloningAttachment.attachmentType;

        //destroy original
        Destroy(cloningAttachment);

        print(this.gameObject.name);
    }

    public void syncRopePosition(Transform targetTrans, int vertices, bool startFromHead)
    {
        //int targetParticle = startFromHead ? rope.elements[vertices].particle1 : rope.elements[rope.elements.Count - 1 - vertices].particle2;
        int targetParticle;
        if (startFromHead)
        {
            targetParticle = rope.elements[vertices].particle1;
        }
        else
        {
            targetParticle = rope.elements[rope.elements.Count - 1 - vertices].particle2;
        }

        rope.solver.positions[targetParticle] = targetTrans.position;

    }

    public void syncRopePosition(Transform targetTrans, int vertices)
    {
        syncRopePosition(targetTrans, vertices, true);
    }

    public void syncRopePosition(GameObject targetObj, int vertices, bool startFromHead)
    {
        syncRopePosition(targetObj.transform, vertices, startFromHead);
    }

    public void syncRopePosition(GameObject targetObj, int vertices)
    {
        syncRopePosition(targetObj.transform, vertices, true);
    }
}
