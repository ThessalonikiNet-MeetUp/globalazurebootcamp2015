package com.example.skgazure2015;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.TextView;

import org.w3c.dom.Text;

/**
 * Adapter to bind a Lecture List to a view
 */
public class CommentAdapter extends ArrayAdapter<Comment> {

    /**
     * Adapter context
     */
    Context mContext;

    /**
     * Adapter View layout
     */
    int mLayoutResourceId;

    public CommentAdapter(Context context, int layoutResourceId) {
        super(context, layoutResourceId);

        mContext = context;
        mLayoutResourceId = layoutResourceId;
    }

    /**
     * Returns the view for a specific item on the list
     */
    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View row = convertView;

        final Comment currentItem = getItem(position);

        if (row == null) {
            LayoutInflater inflater = ((Activity) mContext).getLayoutInflater();
            row = inflater.inflate(mLayoutResourceId, parent, false);
        }

        row.setTag(currentItem);

        final TextView whenTextView = (TextView) row.findViewById(R.id.whenDate);
        final TextView commentTextView = (TextView) row.findViewById(R.id.comment);
        final TextView authorTextView = (TextView) row.findViewById(R.id.author);

        //whenTextView.setText(currentItem());
        commentTextView.setText(currentItem.getDescription());
        authorTextView.setText(currentItem.getAuthor());
        if(currentItem.getWhen()!=null)
        {
            whenTextView.setText(currentItem.getWhen().toString());
        }

        return row;
    }

}