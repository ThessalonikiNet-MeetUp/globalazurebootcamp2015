package com.example.skgazure2015;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.TextView;

/**
 * Adapter to bind a Lecture List to a view
 */
public class LectureAdapter extends ArrayAdapter<Lecture> {

    /**
     * Adapter context
     */
    Context mContext;

    /**
     * Adapter View layout
     */
    int mLayoutResourceId;

    public LectureAdapter(Context context, int layoutResourceId) {
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

        final Lecture currentItem = getItem(position);

        if (row == null) {
            LayoutInflater inflater = ((Activity) mContext).getLayoutInflater();
            row = inflater.inflate(mLayoutResourceId, parent, false);
        }

        row.setTag(currentItem);
        final CheckBox checkBox = (CheckBox) row.findViewById(R.id.checkToDoItem);

        checkBox.setText(currentItem.getTitle());
        checkBox.setChecked(false);
        checkBox.setEnabled(true);
        if(currentItem.getWhen()!=null) {
            final TextView whenText = (TextView) row.findViewById(R.id.whenDate);
            whenText.setText(currentItem.getWhen().toString());
        }

        checkBox.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View arg0) {
                if (checkBox.isChecked()) {
                    checkBox.setEnabled(false);
                    if (mContext instanceof LectureActivity) {
                        LectureActivity activity = (LectureActivity) mContext;
                        activity.checkItem(currentItem);
                    }
                }
            }
        });

        return row;
    }

}