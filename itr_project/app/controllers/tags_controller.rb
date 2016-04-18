class TagsController < ApplicationController

  def index
    if params[:term].end_with? ","
      tags = []
    else
      params[:term] = params[:term].split(", ").last
      tags = Tag.limit(3).where('tags.name LIKE ?', "%#{params[:term]}%").pluck("tags.name")
    end
    render :json => tags
  end

end