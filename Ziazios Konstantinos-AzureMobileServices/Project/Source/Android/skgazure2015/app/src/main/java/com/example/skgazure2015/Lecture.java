package com.example.skgazure2015;

import java.util.Date;

/**
 * Represents an item in a ToDo list
 */
public class Lecture {

    /**
     * Item text
     */
    @com.google.gson.annotations.SerializedName("title")
    private String mTitle;


    @com.google.gson.annotations.SerializedName("id")
    private String mId;

    @com.google.gson.annotations.SerializedName("description")
    private String mDescription;
    @com.google.gson.annotations.SerializedName("author")
    private String mAuthor;

    @com.google.gson.annotations.SerializedName("when")
    private Date mWhen;


    /**
     * Indicates if the item is completed
     */
    @com.google.gson.annotations.SerializedName("complete")
    private boolean mComplete;

    /**
     * Lecture constructor
     */
    public Lecture() {

    }

    @Override
    public String toString() {
        return getTitle();
    }

    /**
     * Initializes a new Lecture
     *
     * @param title
     *            The item text
     * @param id
     *            The item id
     */
    public Lecture(String title, String id, String description, String author, Date when ) {
        this.setTitle(title);

        this.setId(id);
    }

    /**
     * Returns the item text
     */
    public String getTitle() {
        return mTitle;
    }

    /**
     * Sets the item text
     *
     * @param title
     *            text to set
     */
    public final void setTitle(String title) {
        mTitle = title;
    }

    /**
     * Returns the item id
     */
    public String getId() {
        return mId;
    }

    /**
     * Sets the item id
     *
     * @param id
     *            id to set
     */
    public final void setId(String id) {
        mId = id;
    }


    /**
     * Indicates if the item is marked as completed
     */
    public boolean isComplete() {
        Date now = new Date();
        return (mWhen == null) || (mWhen.before(now));
        //return mComplete;
    }

    /**
     * Marks the item as completed or incompleted
     */
    public void setComplete(boolean complete) {
        mWhen = new Date();
    }

    @Override
    public boolean equals(Object o) {
        return o instanceof Lecture && ((Lecture) o).mId == mId;
    }

    /**
     * Item description
     */
    public String getDescription() {
        return mDescription;
    }

    public void setDescription(String mDescription) {
        this.mDescription = mDescription;
    }

    /**
     * author
     */
    public String getAuthor() {
        return mAuthor;
    }

    public void setAuthor(String mAuthor) {
        this.mAuthor = mAuthor;
    }

    /**
     * when
     */
    public Date getWhen() {
        return mWhen;
    }

    public void setWhen(Date mWhen) {
        this.mWhen = mWhen;
    }
}