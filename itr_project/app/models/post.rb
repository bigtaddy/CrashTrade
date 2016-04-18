class Post < ActiveRecord::Base
  acts_as_voteable
  belongs_to :user
  acts_as_taggable # <= это добавили
  attr_accessible :title, :content, :tag_list
end
